use std::fs::File;
use std::io::{Read, Seek, SeekFrom, Write};

mod files;
use files::{FileStream, SimpleFileStream};

#[repr(align(1024))]
#[derive(Debug)]
pub struct MetaData {
    version: u8,
    time_stamp: u64,
}

#[derive(Debug)]
pub struct TestData {
    stream_id: i32,
    data_length: i32,
    data_position: i64,
}

const FILE_NAME: &str = "C:/temp/eventstore.es";
const EVENT_STORE_VERSION: u8 = 1;

pub struct EventStore {
    file: File,
    metadata: MetaData,
}

impl EventStore {
    pub fn print_metadata(&self) {
        println!("{:?}", self.metadata);
    }

    pub fn new(location: &str, file_stream: &FileStream) -> Result<Self, &'static str> {
        match EventStore::read_event_store(location, file_stream) {
            Ok(event_store) => Ok(event_store),
            Err(_) => EventStore::create_event_store(location, file_stream),
        }
    }

    fn read_event_store(location: &str, file_stream: &FileStream) -> Result<Self, &'static str> {
        match file_stream.open(location) {
            Ok(mut file) => match EventStore::read_metadata(&mut file) {
                Ok(metadata) => {
                    assert_eq!(EVENT_STORE_VERSION, metadata.version, "Version mismatch, possible corrupt data.");
                    Ok(EventStore {
                        file: file,
                        metadata: metadata,
                    })
                }
                Err(e) => panic!("Failed to read metadata from file. Can't recover from this."),
            },
            Err(e) => Err("Failed to open file"),
        }
    }

    fn read_metadata(file: &mut File) -> Result<MetaData, &'static str> {
        match file.seek(SeekFrom::Start(0)) {
            Ok(_) => {
                let buffer: &mut [u8] = &mut [0u8; core::mem::size_of::<MetaData>()];
                match file.read(buffer) {
                    Ok(_) => Ok(unsafe { std::ptr::read(buffer.as_ptr() as *const _) }),
                    Err(e) => panic!(e),
                }
            }
            Err(_) => Err("Failed to read metadata"),
        }
    }

    fn create_event_store(location: &str, file_stream: &FileStream) -> Result<Self, &'static str> {
        match file_stream.create(location) {
            Ok(file) => {
                let mut event_store = EventStore {
                    file: file,
                    metadata: EventStore::create_metadata(),
                };
                event_store.write_metadata()?;
                Ok(event_store)
            }
            Err(e) => Err(e),
        }
    }

    pub fn write_metadata(&mut self) -> Result<(), &'static str> {
        assert_eq!(
            1024,
            std::mem::size_of::<MetaData>(),
            "Metadata must be of size 1024 bytes"
        );

        let bytes = unsafe { EventStore::any_as_u8_slice(&self.metadata) };
        let seek_result = self.file.seek(SeekFrom::Start(0));
        if seek_result.is_err() {
            println!("{:?}", seek_result.err());
            return Err("Failed to set pointer at start");
        }

        match self.file.write(&bytes) {
            Ok(_) => Ok(()),
            Err(e) => {
                println!("{:?}", e);
                Err("Failed to write metadata")
            }
        }
    }

    fn create_metadata() -> MetaData {
        MetaData {
            version: 1,
            time_stamp: 1300,
        }
    }

    unsafe fn any_as_u8_slice<T: Sized>(p: &T) -> &[u8] {
        ::std::slice::from_raw_parts((p as *const T) as *const u8, ::std::mem::size_of::<T>())
    }
}

fn main() {
    let file_stream = SimpleFileStream {};
    match EventStore::new(FILE_NAME, &file_stream) {
        Ok(event_store) => {
            println!("Created the event store");
            event_store.print_metadata()
        }
        Err(e) => println!("Failed to create event store with message: {}", e),
    };
}
