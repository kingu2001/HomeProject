using System.ComponentModel.DataAnnotations;

namespace DependencyInjectionTest.Models
{
    public class Dummy : IDummy
    {
        public string Write(string message)
        {
            return message;
        }
    }
}
