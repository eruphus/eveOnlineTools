/*
    Copyright 2012 Alexander Wölfel 
 
    This file is part of eveStatic.

    eveStatic is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License.

    eveStatic is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

    Diese Datei ist Teil von eveStatic.

    EveStatic ist Freie Software: Sie können es unter den Bedingungen
    der GNU General Public License, wie von der Free Software Foundation,
    Version 3 der Lizenz weiterverbreiten und/oder modifizieren.

    EveStatic wird in der Hoffnung, dass es nützlich sein wird, aber
    OHNE JEDE GEWÄHELEISTUNG, bereitgestellt; sogar ohne die implizite
    Gewährleistung der MARKTFÄHIGKEIT oder EIGNUNG FÜR EINEN BESTIMMTEN ZWECK.
    Siehe die GNU General Public License für weitere Details.

    Sie sollten eine Kopie der GNU General Public License zusammen mit diesem
    Programm erhalten haben. Wenn nicht, siehe <http://www.gnu.org/licenses/>. 
 
 */

using System.Drawing;
using System.IO;
using libEveStatic.database.entities.INV;

namespace libEveStatic.pictures
{
    public enum PictureSize
    {
        Small = 32,
        Big = 64
    }

    public class MultiSizePictureProvider
    {
        private const string EveStaticPicturesExtension = "png";

        private readonly DirectoryInfo _baseDirectory;

        public MultiSizePictureProvider(DirectoryInfo baseDirectory)
        {
            _baseDirectory = baseDirectory;
        }

        private string GetTargetFileName (InventoryType type, PictureSize size)
        {
            return string.Format("{0}_{1}.{2}", type.Id, size, EveStaticPicturesExtension);
        }

        private FileInfo GetTargetFile(InventoryType type, PictureSize size)
        {
            var matchingFiles = _baseDirectory.GetFiles(GetTargetFileName(type, size));
            if (matchingFiles.Length == 0) return null;
            return matchingFiles[0];
        }

        private bool PictureExists(InventoryType type, PictureSize size)
        {
            return GetTargetFile(type, size) != null;
        }

        public Image GetImage(InventoryType type, PictureSize size)
        {
            if (!PictureExists(type, size)) return null;
            return Image.FromStream(GetTargetFile(type, size).OpenRead());
        }
    }
}