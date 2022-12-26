namespace class_Library
{
    public class FileProcess
    {
        public bool FileExits(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("fileName");
            }
            return File.Exists(filename);
        }
    }
}