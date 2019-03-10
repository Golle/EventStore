use std::fs::{File, OpenOptions};
use std::io::{Write};

struct TestData32<'a> {
    stream_id: i128,
    commit_id: i128,
    sequence_number: i64,
    data_length: i32,
    data: &'a [u8; 32]
}
struct TestData64<'a> {
    stream_id: i128,
    commit_id: i128,
    sequence_number: i64,
    data_length: i32,
    data: &'a [u8; 64]
}




unsafe fn any_as_u8_slice<T: Sized>(p: &T) -> &[u8] {
    ::std::slice::from_raw_parts((p as *const T) as *const u8, ::std::mem::size_of::<T>())
}



fn main() {
    {   
        File::create("C:/temp/evenstore.es").unwrap();
    }
    {
        let mut f = OpenOptions::new().append(true).open("C:/temp/evenstore.es").unwrap();
        let vector32: &[u8; 32] = &[0; 32];
        let data = TestData32{stream_id: 32, commit_id: 54, sequence_number: 11, data_length: 12, data: vector32 };
        let bytes = unsafe{any_as_u8_slice(&data)};
        // for _ in 0..10000 {
        // match f.write_all(&bytes) {
        //     Ok(_) => {},
        //     Err(e) => println!("Failed with error: {}", e)
        // };
    // }
    // f.flush().unwrap();
    }
    {
        let mut f = OpenOptions::new().read(true).open("C:/temp/evenstore.es").unwrap();
        f.read

    }

    
}