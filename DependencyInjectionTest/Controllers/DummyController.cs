using DependencyInjectionTest.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace DependencyInjectionTest.Controllers
{
    public class DummyController : Controller
    {
        private readonly IDummy IMessage; 
        public DummyController(IDummy Imessage)
        {
            IMessage = Imessage;
        }

        public string Index()
        {
            return IMessage.Write("Hello, World!");
        }

    }
}
