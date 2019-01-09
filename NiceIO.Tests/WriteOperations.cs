using System;
using System.IO;
using NUnit.Framework;

namespace SpoiledCat.NiceIO.Tests
{
	[TestFixture]
	public class WriteOperations : TestWithTempDir
	{
		[Test]
		public void WriteAllText()
		{
			Assert.AreEqual("hello there", _tempPath.Combine("mydir/myfile").WriteAllText("hello there").ReadAllText());
		}

		[Test]
		public void WriteAllLines()
		{
			CollectionAssert.AreEqual(new[] {"hello", "there"}, _tempPath.Combine("mydir/myfile").WriteAllLines(new[] {"hello", "there"}).ReadAllLines());
		}

		[Test]
		public void OnRelativeFile_WriteText()
		{
			Assert.AreEqual("hi", new NPath("relative").WriteAllText("hi").ReadAllText());
		}

		[Test]
		public void OnRelativeFile_WriteLines()
		{
			CollectionAssert.AreEqual(new [] { "hi" }, new NPath("relative").WriteAllLines(new[]{"hi"}).ReadAllLines());
		}

		[Test]
		public void OnRelativeFile_ReadText()
		{
			Assert.Throws<FileNotFoundException>(() => new NPath("relative").ReadAllText());
			PopulateTempDir(new[] { "relative" });
			new NPath("relative").ReadAllText();
		}

		[Test]
		public void OnRelativeFile_ReadLines()
		{
			Assert.Throws<FileNotFoundException>(() => new NPath("relative").ReadAllLines());
			PopulateTempDir(new[] { "relative" });
			new NPath("relative").ReadAllLines();
		}
	}
}
