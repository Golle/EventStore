use std::fs::{File, OpenOptions};

use super::filestream::FileStream;

pub struct SimpleFileStream {}

impl FileStream for SimpleFileStream {
    fn create(&self, filename: &str) -> Result<File, &'static str> {
        match File::create(filename) {
            Ok(file) => Ok(file),
            Err(_) => Err("Failed to create file")
        }
    }

    fn open(&self, filename: &str) -> Result<File, &'static str>{
        match OpenOptions::new().write(true).read(true).open(filename) {
            Ok(file) => Ok(file),
            Err(_) => Err("Failed to open file for write")
        }
    }
}