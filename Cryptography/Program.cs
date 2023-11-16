namespace Cryptography
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Cryptography cryptography = new Cryptography();

			Console.WriteLine(cryptography.GetHashValue("skattekronen"));
			Console.WriteLine(cryptography.GetHashValue("tanketorsken"));
			Console.WriteLine(cryptography.GetHashValue("tanketorsken"));
			Console.ReadLine(); 
		}
	}

	public class Cryptography
	{
		public int GetHashValue(string password)
		{
			int result = 0;
			int multiplier = 1;
			foreach (char ch in password)
			{
				result += ch.GetHashCode() * multiplier;
				multiplier++;
			}
			return result % 100;
		}
	}
}