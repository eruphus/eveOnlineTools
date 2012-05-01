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

using System.IO;
using libEveStatic.pictures;
using libUtils.Core;

namespace libEveStatic
{
    public class EveStaticPictures : PluginBase
    {

        private const string EveStaticPicturesConfigSection = "pictures";
        private EveStaticPicturesConfiguration _configuration;

        private PictureProvider _renderProvider;
        private MultiSizePictureProvider _typeProvide;

        private EveStaticPicturesConfiguration Configuration 
        {
            get
            {
                return _configuration ?? (_configuration = ApplicationCore.GetService<IConfigurationProvider>().GetConfiguration<EveStaticPicturesConfiguration>(EveStaticPicturesConfigSection));
            }
        }

        
        public override void Initialize()
        {
            base.Initialize();
            ApplicationCore.RegisterService(this);
        }

        private bool IsValidPictureSource(string target) { return !string.IsNullOrEmpty(target) && Directory.Exists(target); }

        public bool HasRenderRepository { get { return IsValidPictureSource(Configuration.RendersDirectory); } }
        public bool HasTypeRepository { get { return IsValidPictureSource(Configuration.TypesDirectory); } }


        public PictureProvider RenderRepository { get { return _renderProvider ?? (_renderProvider = new PictureProvider(new DirectoryInfo(Configuration.RendersDirectory))); } }
        public MultiSizePictureProvider TypeRepository { get { return _typeProvide ?? (_typeProvide = new MultiSizePictureProvider(new DirectoryInfo(Configuration.TypesDirectory))); } }

 
    }
}