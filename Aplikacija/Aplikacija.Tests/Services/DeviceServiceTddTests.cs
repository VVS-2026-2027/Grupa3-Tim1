using Aplikacija.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aplikacija.Tests.Services;

[TestClass]
[TestCategory("TDD")]
public class DeviceServiceTddTests
{
    private static readonly DateTime Sada = new DateTime(2026, 11, 20, 12, 0, 0);
    private DeviceService _servis = null!;

    [TestInitialize]
    public void Setup()
    {
        _servis = new DeviceService();
    }
}