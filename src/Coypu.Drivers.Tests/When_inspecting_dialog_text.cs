﻿using System;
using Coypu.Drivers.Selenium;
using Coypu.Drivers.Watin;
using NSpec;

namespace Coypu.Drivers.Tests
{
	internal class When_inspecting_dialog_text : DriverSpecs
	{
		//[NotSupportedBy(typeof(WatiNDriver))] // with FF 3
		[NotSupportedBy(typeof(WatiNDriver), typeof(SeleniumWebDriver))] // with FF 4
		internal override void Specs()
		{
			it["should find exact text in alert"] = () => 
			{
				using (driver)
				{
					driver.Click(driver.FindLink("Trigger an alert"));
					driver.HasDialog("You have triggered an alert and this is the text.");
					driver.HasDialog("You have triggered a different alert and this is the different text.").should_be_false();
				}
			};

			it["should find exact text in confirm"] = () =>
			{
				using (driver)
				{
					driver.Click(driver.FindLink("Trigger a confirm"));
					driver.HasDialog("You have triggered a confirm and this is the text.");
					driver.HasDialog("You have triggered a different confirm and this is the different text.").should_be_false();
				}
			};
		}
	}
}