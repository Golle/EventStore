use std::fs::File;

pub trait FileStream {
    fn open(&self, filename: &str) -> Result<File, &'static str>;
    fn create(&self, filename: &str) -> Result<File, &'static str>;
}

