using DataStructuresToolkit.Recursion;

namespace DataStructuresToolkit.Tests;

public class RecursionHelpersTests
{
    [SetUp]
    public void Setup()
    {
    }

	[TestCase(0, 1)]
	[TestCase(1, 1)]
	[TestCase(5, 120)]
	public void Factorial_ValidInput_ReturnsExpected(int n, long expected)
	{
		long result = RecursionHelpers.Factorial(n);
		Assert.That(result, Is.EqualTo(expected));
	}

	[Test]
	public void Factorial_NegativeNumber_ThrowsArgumentException()
	{
		Assert.That(() => RecursionHelpers.Factorial(-1), Throws.ArgumentException);
	}

	[Test]
	public void Factorial_LargerValue_CompletesSuccessfully()
	{
		long result = RecursionHelpers.Factorial(10);
		Assert.That(result, Is.EqualTo(3628800));
	}

	[TestCase("racecar", true)]
	[TestCase("madam", true)]
	[TestCase("hello", false)]
	public void IsPalindrome_ValidStrings_ReturnsExpected(string input, bool expected)
	{
		bool result = RecursionHelpers.IsPalindrome(input);
		Assert.That(result, Is.EqualTo(expected));
	}

	[TestCase("", true)]
	[TestCase("a", true)]
	public void IsPalindrome_EdgeCases_ReturnsExpected(string input, bool expected)
	{
		bool result = RecursionHelpers.IsPalindrome(input);
		Assert.That(result, Is.EqualTo(expected));
	}

	[Test]
	public void IsPalindrome_NonPalindrome_ReturnsFalse()
	{
		bool result = RecursionHelpers.IsPalindrome("Toothbrush");
		Assert.That(result, Is.EqualTo(false));
	}

	[Test]
	public void PrintDirectory_NonExistentDirectory_ThrowsException()
	{
		Assert.That(() => RecursionHelpers.PrintDirectory("Z:\\Placeholder"), Throws.TypeOf<DirectoryNotFoundException>());
	}

	[Test]
	public void PrintDirectory_EmptyDirectory_ExecutesWithoutError()
	{
		string tempDir = Path.Combine(Path.GetTempPath(), "Placeholder_Directory");
		Directory.CreateDirectory(tempDir);

		Assert.That(() => RecursionHelpers.PrintDirectory(tempDir), Throws.Nothing);

		Directory.Delete(tempDir, true);
	}
}
