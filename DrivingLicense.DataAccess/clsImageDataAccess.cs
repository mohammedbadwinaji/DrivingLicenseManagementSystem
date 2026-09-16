using System;
using System.IO;


namespace DrivingLicense.DataAccess
{
	using System;
	using System.IO;

	internal class clsImageDataAccess
	{
		
		public static string InsertImage(string sourceImagePath)
		{
			if (string.IsNullOrWhiteSpace(sourceImagePath) || !File.Exists(sourceImagePath))
			{
				return null;
			}

			try
			{
				if (!Directory.Exists(clsSettings.imageStorageDirectory))
				{
					Directory.CreateDirectory(clsSettings.imageStorageDirectory);
				}

				string uniqueId = Guid.NewGuid().ToString();
				string extension = Path.GetExtension(sourceImagePath);
				string newFileName = uniqueId + extension;

				string targetImagePath = Path.Combine(clsSettings.imageStorageDirectory, newFileName);

				File.Copy(sourceImagePath, targetImagePath, overwrite: false);

				return targetImagePath; 
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static string UpdateImage(string oldImagePath, string newSourceImagePath)
		{
			DeleteImage(oldImagePath);
			return InsertImage(newSourceImagePath);
		}

		public static bool DeleteImage(string imagePath)
		{
			if (string.IsNullOrWhiteSpace(imagePath))
			{
				return true;
			}

			try
			{
				if (File.Exists(imagePath))
				{
					File.Delete(imagePath);
				}
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}

}