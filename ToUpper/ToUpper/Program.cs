using System;
using System.Data.SqlTypes;
using System.IO;
using System.Threading.Tasks;

namespace ToUpper
{

    //class Program
    //{
    //    private const string _infilesFolder = "infiles";
    //    private const string _outfilesFolder = "outfiles";
    //    private const string _infilenameBasis = _infilesFolder + "\\splitfile";
    //    private const string _outfilenameBasis = _outfilesFolder + "\\UPPERsplitfile";
    //    private const string _fileExtension = ".txt";
    //    private int _sheepCount = default;

    //    static void Main(string[] args)
    //    {
    //        Program prog = new Program();
    //        prog.MainThread();
    //    }

    //    private void MainThread()
    //    {
    //        int fileCount = Directory.GetFiles(_infilesFolder).Length;
    //        Console.WriteLine($"Starting job - {fileCount} files");
    //        Job(fileCount);
    //        Console.WriteLine("Job is done");
    //        Console.ReadKey();
    //    }

    //    public void Job(int fileCount)
    //    {
    //        for (int i = 1; i <= fileCount; i++)
    //        {
    //            FileInfo fi = new FileInfo(_infilenameBasis + i + _fileExtension);
    //            int fileSize = (int)fi.Length;
    //            char[] charbuf = new char[fileSize];

    //            using (StreamReader sr = fi.OpenText())
    //            {
    //                using (StreamWriter sw = File.CreateText(_outfilenameBasis + i + _fileExtension))
    //                {
    //                    //PUT IN YOUR CODE HERE: 
    //                    // - create a Task<?> that reads file into charbuf asyncronously
    //                    // - call CountSheep(…), 
    //                    // - convert charbuf to upper case (Char.ToUpper(…);)
    //                    // - write charbuf to disk using the StreamWriter
    //                    Task<int> t1 = new Task<int>(() =>
    //                    {
    //                        var result = sr.ReadAsync(charbuf, 0, fileSize);
    //                        return result.Result;
    //                    });
    //                    t1.Start();
    //                    CountSheep(t1);
    //                    t1.Wait();
    //                    char[] tempBuffer = new char[t1.Result];
    //                    tempBuffer = charbuf;
    //                    for (int j = 0; j < tempBuffer.Length; j++)
    //                    {
    //                        tempBuffer[j] = char.ToUpper(tempBuffer[j]);
    //                    }
    //                    sw.WriteLineAsync(tempBuffer);
    //                }
    //            }
    //        }
    //    }

    //    private void CountSheep(Task job)
    //    {//you have to find out what the type XYZ should be…
    //        while ((job.Status != TaskStatus.RanToCompletion))
    //        {
    //            Console.WriteLine(_sheepCount + " sheep");
    //            _sheepCount++;
    //        }
    //    }
    //}

    class Program
    {
        private const string _infilesFolder = "infiles";
        private const string _outfilesFolder = "outfiles";
        private const string _infilenameBasis = _infilesFolder + "\\splitfile";
        private const string _outfilenameBasis = _outfilesFolder + "\\UPPERsplitfile";
        private const string _fileExtension = ".txt";
        private bool _jobIsRunning = default;

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.MainThread();
        }

        private void MainThread()
        {
            int fileCount = Directory.GetFiles(_infilesFolder).Length;
            Console.WriteLine($"Starting job - {fileCount} files");
            Job(fileCount);
            CountSheep();
            Console.WriteLine("Job is done");
            Console.ReadKey();
        }

        public async void Job(int fileCount)
        {
            _jobIsRunning = true;
            for (int i = 1; i <= fileCount; i++)
            {
                FileInfo fi = new FileInfo(_infilenameBasis + i + _fileExtension);
                int fileSize = (int)fi.Length;
                char[] charbuf = new char[fileSize];

                //Create StreamReader and StreamWrite so the method runs asynchronously
                //as soon as the StreamWriter is created.
                //Read file into charbuf, convert to upper case and write using the 
                //StreamWriter exactly as before

                using (StreamReader sr = fi.OpenText())
                {
                    using (StreamWriter sw = File.CreateText(_outfilenameBasis + i + _fileExtension))
                    {
                        await sr.ReadAsync(charbuf, 0, fileSize);
                        char[] arrayToUpper = charbuf;
                        for (int j = 0; j < arrayToUpper.Length; j++)
                        {
                            arrayToUpper[j] = char.ToUpper(arrayToUpper[j]);
                        }
                        sw.WriteLineAsync(arrayToUpper);
                    }
                }
            }
            _jobIsRunning = false;
        }

        private void CountSheep()
        {
            int i = 1;
            while (_jobIsRunning)
            {
                Console.WriteLine(i + " sheep");
                i++;
            }
        }
    }

}
