﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace NiceIO.Tests
{
	[TestFixture]
	public class RelativeTo
	{
		[Test]
		public void ToBaseDirectory()
		{
			var relative = new Path("/mydir1/mydir2/myfile").RelativeTo(new Path("/mydir1"));
			Assert.AreEqual("mydir2/myfile", relative.ToString());
			Assert.IsTrue(relative.IsRelative);
		}

		[Test]
		public void RootedAndRelative()
		{
			Assert.Throws<ArgumentException>(() => new Path("/mydir1/mydir2/myfile").RelativeTo(new Path("myfile")));			
		}

		[Test]
		public void RelativeAndRooted()
		{
			Assert.Throws<ArgumentException>(() => new Path("mydir1/mydir2/myfile").RelativeTo(new Path("/mydir1")));
		}

		[Test]
		public void WithDifferentDriveLetters()
		{
			Assert.Throws<ArgumentException>(() => new Path("c:/mydir1/mydir2/myfile").RelativeTo(new Path("d:/mydir1")));
		}

		[Test]
		public void RelativeAndRelative()
		{
			Assert.AreEqual("mydir2/myfile",new Path("mydir1/mydir2/myfile").RelativeTo(new Path("mydir1")).ToString());
		}

		[Test]
		public void ToAnUnrelatedDirectory()
		{
			Assert.Throws<ArgumentException>(()=>new Path("/mydir1/mydir2/myfile").RelativeTo(new Path("/unrelated")));
		}
	}
}