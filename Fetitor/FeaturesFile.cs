// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Fetitor
{
	/// <summary>
	/// Represents "Setting" entry in "features.xml.compiled".
	/// </summary>
	public class FeaturesSetting
	{
		public bool Development;
		public byte Generation;
		public string Locale = "";
		public string Name = "";
		public byte Season;
		public byte Subseason;
		public bool Test;
	}

	/// <summary>
	/// Represents "Feature" entry in "features.xml.compiled".
	/// </summary>
	public class FeaturesFeature
	{
		public string Default = "";
		public string Disable = "";
		public string Enable = "";
		public uint Hash;
		public string Name;
	}

	/// <summary>
	/// Reader and writer for features.xml(.compiled).
	/// </summary>
	public class FeaturesFile
	{
		private readonly byte[] _strBuffer = new byte[0x100];

		private readonly List<FeaturesSetting> _settings = new List<FeaturesSetting>();
		private readonly List<FeaturesFeature> _features = new List<FeaturesFeature>();

		private static readonly Dictionary<uint, string> _featureNames = new Dictionary<uint, string>();
		private static readonly HashSet<string> _completeFeatureNames = new HashSet<string>();

		/// <summary>
		/// Returns the number of features names loaded.
		/// </summary>
		public static int FetureNameCount => _completeFeatureNames.Count;

		/// <summary>
		/// Creates new FeaturesFile.
		/// </summary>
		public FeaturesFile()
		{
		}

		/// <summary>
		/// Creates new FeaturesFile from file.
		/// </summary>
		/// <param name="filePath"></param>
		private FeaturesFile(string filePath)
		{
			if (!File.Exists(filePath))
				throw new FileNotFoundException("File not found: " + filePath);

			var ext = Path.GetExtension(filePath);
			if (ext != ".xml" && ext != ".compiled")
				throw new InvalidDataException("Invalid file extension.");

			using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				if (ext == ".xml")
					this.LoadFromXml(stream);
				else
					this.LoadFromCompiled(stream);
			}
		}

		/// <summary>
		/// Loads features names from text file.
		/// </summary>
		/// <param name="filePath"></param>
		public static void LoadFeatureNames(string filePath)
		{
			using (var sr = new StreamReader(filePath))
			{
				string line = null;
				while ((line = sr.ReadLine()) != null)
				{
					var name = line.Trim();
					if (name == "" || name.StartsWith("//"))
						continue;

					var hash = GetStringHash(name);

					_featureNames[hash] = name;
					_completeFeatureNames.Add(name);
				}
			}
		}

		/// <summary>
		/// Hashes str.
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static uint GetStringHash(string str)
		{
			var s = 5381;
			foreach (var ch in str) s = s * 33 + (int)ch;
			return (uint)s;
		}

		/// <summary>
		/// Loads settings and features from .xml file.
		/// </summary>
		/// <param name="filePath"></param>
		public void LoadFromXml(string filePath)
		{
			using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
				this.LoadFromXml(stream);
		}

		/// <summary>
		/// Loads settings and features from .xml file.
		/// </summary>
		/// <param name="stream"></param>
		public void LoadFromXml(Stream stream)
		{
			using (var xml = XmlReader.Create(stream))
			{
				xml.ReadToFollowing("Settings");
				using (var settingsXml = xml.ReadSubtree())
				{
					while (settingsXml.ReadToFollowing("Setting"))
					{
						var setting = new FeaturesSetting();
						setting.Name = settingsXml.GetAttribute("Name");
						setting.Locale = settingsXml.GetAttribute("Locale");
						setting.Test = Convert.ToBoolean(settingsXml.GetAttribute("Test"));
						setting.Development = Convert.ToBoolean(settingsXml.GetAttribute("Development"));
						setting.Generation = Convert.ToByte(settingsXml.GetAttribute("Generation"));
						setting.Season = Convert.ToByte(settingsXml.GetAttribute("Season"));
						setting.Subseason = Convert.ToByte(settingsXml.GetAttribute("Subseason"));

						_settings.Add(setting);
					}
				}

				xml.ReadToFollowing("Features");
				using (var featuresXml = xml.ReadSubtree())
				{
					while (featuresXml.ReadToFollowing("Feature"))
					{
						var feature = new FeaturesFeature();
						feature.Hash = Convert.ToUInt32(featuresXml.GetAttribute("Hash") ?? featuresXml.GetAttribute("_Name"), 16);
						feature.Name = featuresXml.GetAttribute("Hash") != null ? featuresXml.GetAttribute("Name") : featuresXml.GetAttribute("_RealName");
						feature.Default = featuresXml.GetAttribute("Default");
						feature.Enable = featuresXml.GetAttribute("Enable");
						feature.Disable = featuresXml.GetAttribute("Disable");

						_features.Add(feature);
					}
				}
			}
		}

		/// <summary>
		/// Saves loaded settings and features in XML format.
		/// </summary>
		/// <param name="filePath"></param>
		public void SaveAsXml(string filePath)
		{
			using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
				this.SaveAsXml(fs);
		}

		/// <summary>
		/// Returns settings and features in XML format.
		/// </summary>
		/// <param name="filePath"></param>
		public string GetXml()
		{
			using (var ms = new MemoryStream())
			{
				this.SaveAsXml(ms);
				return Encoding.UTF8.GetString(ms.ToArray());
			}
		}

		/// <summary>
		/// Returns compiled features file in XML format.
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public static string GetXmlFromCompiled(string filePath)
		{
			var ff = new FeaturesFile(filePath);
			return ff.GetXml();
		}

		/// <summary>
		/// Saves given XML file at path in compiled format.
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public static void SaveCompiledFromXml(string filePath, string xml)
		{
			var ff = new FeaturesFile();

			using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
				ff.LoadFromXml(ms);

			ff.SaveAsCompiled(filePath);
		}

		/// <summary>
		/// Saves loaded settings and features in XML format.
		/// </summary>
		/// <param name="filePath"></param>
		public void SaveAsXml(Stream stream)
		{
			using (var writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true, IndentChars = "\t" }))
			{
				writer.WriteStartDocument();
				{
					writer.WriteStartElement("FeatureList");
					{
						writer.WriteStartElement("Settings");
						foreach (var setting in _settings)
						{
							writer.WriteStartElement("Setting");
							writer.WriteAttributeString("Name", setting.Name);
							writer.WriteAttributeString("Locale", setting.Locale);
							writer.WriteAttributeString("Test", setting.Test.ToString());
							writer.WriteAttributeString("Development", setting.Development.ToString());
							writer.WriteAttributeString("Generation", setting.Generation.ToString());
							writer.WriteAttributeString("Season", setting.Season.ToString());
							writer.WriteAttributeString("Subseason", setting.Subseason.ToString());
							writer.WriteEndElement();
						}
						writer.WriteEndElement();

						writer.WriteStartElement("Features");
						foreach (var feature in _features)
						{
							writer.WriteStartElement("Feature");
							writer.WriteAttributeString("Hash", feature.Hash.ToString("x8"));
							writer.WriteAttributeString("Name", feature.Name);
							writer.WriteAttributeString("Default", feature.Default);
							writer.WriteAttributeString("Enable", feature.Enable);
							writer.WriteAttributeString("Disable", feature.Disable);
							writer.WriteEndElement();
						}
						writer.WriteEndElement();
					}
					writer.WriteEndElement();
				}
				writer.WriteEndDocument();
				writer.Close();
			}
		}

		/// <summary>
		/// Loads settings and features from compiled file.
		/// </summary>
		/// <param name="filePath"></param>
		private void LoadFromCompiled(string filePath)
		{
			using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
				this.LoadFromCompiled(stream);
		}

		/// <summary>
		/// Loads settings and features from compiled file.
		/// </summary>
		/// <author>Yiting</author>
		/// <param name="stream"></param>
		private void LoadFromCompiled(Stream stream)
		{
			var buffer = new byte[0x100];

			if (stream.Read(buffer, 0, 2) != 2)
				throw new EndOfStreamException();

			var settingCount = BitConverter.ToUInt16(buffer, 0);
			for (var i = 0; i < settingCount; i++)
			{
				var setting = new FeaturesSetting();

				setting.Name = this.ReadEncryptedLpString(stream);
				setting.Locale = this.ReadEncryptedLpString(stream);

				if (stream.Read(buffer, 0, 3) != 3)
					throw new EndOfStreamException();

				setting.Generation = buffer[0];
				setting.Season = buffer[1];
				setting.Subseason = (byte)(buffer[2] >> 2);
				setting.Test = (buffer[2] & 1) != 0;
				setting.Development = (buffer[2] & 2) != 0;

				_settings.Add(setting);
			}

			if (stream.Read(buffer, 0, 2) != 2)
				throw new EndOfStreamException();

			var featureCount = BitConverter.ToUInt16(buffer, 0);
			for (var j = 0; j < featureCount; j++)
			{
				var feature = new FeaturesFeature();

				if (stream.Read(buffer, 0, 4) != 4)
					throw new EndOfStreamException();

				feature.Hash = BitConverter.ToUInt32(buffer, 0);
				feature.Name = _featureNames.ContainsKey(feature.Hash) ? _featureNames[feature.Hash] : "?";

				feature.Default = this.ReadEncryptedLpString(stream);
				feature.Enable = this.ReadEncryptedLpString(stream);
				feature.Disable = this.ReadEncryptedLpString(stream);

				_features.Add(feature);
			}
		}

		/// <summary>
		/// Reads an encrypted, length-prefixed string from the stream
		/// and returns it.
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		/// <exception cref="EndOfStreamException"></exception>
		/// <exception cref="NotSupportedException"></exception>
		private string ReadEncryptedLpString(Stream stream)
		{
			if (stream.Read(_strBuffer, 0, 2) != 2)
				throw new EndOfStreamException();

			var length = BitConverter.ToUInt16(_strBuffer, 0);
			if (length > _strBuffer.Length)
				throw new NotSupportedException();

			if (length <= 0)
				return "";

			if (stream.Read(_strBuffer, 0, length) != length)
				throw new EndOfStreamException();

			for (var i = 0; i < length; i++)
				_strBuffer[i] = (byte)(_strBuffer[i] ^ 0x80);

			return Encoding.UTF8.GetString(_strBuffer, 0, length);
		}

		/// <summary>
		/// Saves settings and features in compiled format.
		/// </summary>
		/// <param name="filePath"></param>
		private void SaveAsCompiled(string filePath)
		{
			using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
				this.SaveAsCompiled(fs);
		}

		/// <summary>
		/// Saves settings and features in compiled format.
		/// </summary>
		/// <author>Yiting</author>
		/// <param name="stream"></param>
		private void SaveAsCompiled(Stream stream)
		{
			stream.Write(BitConverter.GetBytes(_settings.Count), 0, 2);
			foreach (var setting in _settings)
			{
				if (string.IsNullOrEmpty(setting.Name))
					throw new NotSupportedException();

				if (string.IsNullOrEmpty(setting.Locale))
					throw new NotSupportedException();

				var nameBuffer = Encoding.UTF8.GetBytes(setting.Name);
				for (var num11 = 0; num11 < nameBuffer.Length; num11++)
					nameBuffer[num11] = (byte)(nameBuffer[num11] ^ 0x80);
				stream.Write(BitConverter.GetBytes(nameBuffer.Length), 0, 2);
				stream.Write(nameBuffer, 0, nameBuffer.Length);

				var localeBuffer = Encoding.UTF8.GetBytes(setting.Locale);
				for (var num12 = 0; num12 < localeBuffer.Length; num12++)
					localeBuffer[num12] = (byte)(localeBuffer[num12] ^ 0x80);
				stream.Write(BitConverter.GetBytes(localeBuffer.Length), 0, 2);
				stream.Write(localeBuffer, 0, localeBuffer.Length);

				var genBuffer = new byte[] { setting.Generation, setting.Season, (byte)(setting.Subseason << 2) };
				if (setting.Test)
					genBuffer[2] = (byte)(genBuffer[2] | 1);
				if (setting.Development)
					genBuffer[2] = (byte)(genBuffer[2] | 2);
				stream.Write(genBuffer, 0, 3);
			}

			stream.Write(BitConverter.GetBytes(_features.Count), 0, 2);
			foreach (var feature in _features)
			{
				stream.Write(BitConverter.GetBytes(feature.Hash), 0, 4);
				if (string.IsNullOrEmpty(feature.Default))
				{
					stream.WriteByte(0);
					stream.WriteByte(0);
				}
				else
				{
					var defaultBuffer = Encoding.UTF8.GetBytes(feature.Default);
					for (var num13 = 0; num13 < defaultBuffer.Length; num13++)
						defaultBuffer[num13] = (byte)(defaultBuffer[num13] ^ 0x80);
					stream.Write(BitConverter.GetBytes(defaultBuffer.Length), 0, 2);
					stream.Write(defaultBuffer, 0, defaultBuffer.Length);
				}

				if (string.IsNullOrEmpty(feature.Enable))
				{
					stream.WriteByte(0);
					stream.WriteByte(0);
				}
				else
				{
					var enableBuffer = Encoding.UTF8.GetBytes(feature.Enable);
					for (var num14 = 0; num14 < enableBuffer.Length; num14++)
						enableBuffer[num14] = (byte)(enableBuffer[num14] ^ 0x80);
					stream.Write(BitConverter.GetBytes(enableBuffer.Length), 0, 2);
					stream.Write(enableBuffer, 0, enableBuffer.Length);
				}

				if (string.IsNullOrEmpty(feature.Disable))
				{
					stream.WriteByte(0);
					stream.WriteByte(0);
				}
				else
				{
					var disableBuffer = Encoding.UTF8.GetBytes(feature.Disable);
					for (var num15 = 0; num15 < disableBuffer.Length; num15++)
						disableBuffer[num15] = (byte)(disableBuffer[num15] ^ 0x80);
					stream.Write(BitConverter.GetBytes(disableBuffer.Length), 0, 2);
					stream.Write(disableBuffer, 0, disableBuffer.Length);
				}
			}
		}

		/// <summary>
		/// Reads stream and returns features file in XML format.
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		/// <exception cref="EndOfStreamException"></exception>
		/// <exception cref="NotSupportedException"></exception>
		public static string CompiledToXml(Stream stream)
		{
			var ff = new FeaturesFile();
			ff.LoadFromCompiled(stream);
			return ff.GetXml();
		}

		/// <summary>
		/// Writes XML to stream in compiled format.
		/// </summary>
		/// <param name="xmlStream"></param>
		/// <param name="compiledStream"></param>
		public static void SaveXmlAsCompiled(string xml, Stream compiledStream)
		{
			var ff = new FeaturesFile();
			using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
				ff.LoadFromXml(ms);
			ff.SaveAsCompiled(compiledStream);
		}
	}
}
