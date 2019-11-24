using System;
using Service.Services;
using Xunit;

namespace UnreadableTesting
{

    public class UnreadableTest
    {

        private readonly IUnreadableService _unreadableService;

        public UnreadableTest(IUnreadableService unreadableService) => _unreadableService = unreadableService;
       
        [Fact]
        public void Test1()
        {
            var element = "element";
            var arr = new string[] { "arr", "test", "element", "Nikos", "sport" };
            var expected = new string[] { "arr", "test", "Nikos", "sport" };
            _unreadableService.MakeItReadable(element, arr);
            var actual = _unreadableService.Result;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test2()
        {
            var element = "element";
            var arr = new string[] { "arr", "test", "element1", "Nikos", "sport" };
            var expected = new string[] { "arr", "test", "element1", "Nikos", "sport" };
            _unreadableService.MakeItReadable(element, arr);
            var actual = _unreadableService.Result;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test3()
        {
            var element = "element";
            var arr = new string[] { "arr", "test", "element", "Nikos", "sport","element","Kelesidis","element","element1","Program" };
            var expected = new string[] { "arr", "test", "Nikos", "sport", "Kelesidis", "element1", "Program" };
            _unreadableService.MakeItReadable(element, arr);
            var actual = _unreadableService.Result;
            Assert.Equal(expected, actual);
        }
    }
}
