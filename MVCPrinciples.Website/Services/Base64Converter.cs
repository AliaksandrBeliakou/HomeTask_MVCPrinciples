namespace MVCPrinciples.Website.Services
{
	public class Base64Converter
	{
		public string? FromBinary(byte[]? source)
		{
			if (source is null)
			{
				return null;
			}

			var base64Str = Convert.ToBase64String(source[78..^78]);
			return "data:image/jpg;base64," + base64Str;
		}
	}
}
