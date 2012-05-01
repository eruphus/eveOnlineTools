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

using System.Linq;
using libEveOnlineTools;
using libEveStatic;
using libEveStatic.database.entities.CHR;
using libEveStatic.database.entities.CRP;
using libEveStatic.database.entities.INV;
using libEveStatic.database.entities.PLA;
using libEveStatic.database.entities.TRN;
using libUtils.Core;

namespace EveOnlineToolsTestConsole
{
    class Program
    {
        static void Main()
        {

            using (ApplicationCore.Create<EveOnlineToolsCore>())
            {
                var allTypesWithInstallations = (from g in EveStaticDatabase.Query<InventoryType>() where g.Installations.Count > 0 select g).ToList();

                var allPlanetSchematic = (from g in EveStaticDatabase.Query<PlanetSchematic>() select g).ToList();
                var allControlTowerResources = (from g in EveStaticDatabase.Query<InventoryType>() where g.ControlTowerResources.Count > 0 select g).ToList();
                var allFactions = (from g in EveStaticDatabase.Query<Faction>() select g).ToList();
                var allTypes = (from g in EveStaticDatabase.Query<InventoryType>() where g.Attributes.Count > 0 select g).ToList();
                var allCorps = (from g in EveStaticDatabase.Query<NpcCorporation>() where g.ResearchSkills.Count > 0 select g).ToList();


                var allNpcCorps = (from g in EveStaticDatabase.Query<NpcCorporation>() where g.Name.StartsWith("Urban") select g).ToList();

                var allItems = (from g in EveStaticDatabase.Query<TranslationLanguage>() select g).ToList();
                var allColumns = (from g in EveStaticDatabase.Query<TranslationColumn>() select g).ToList();
                var allTranslations = (from g in EveStaticDatabase.Query<Translation>() select g).ToList();

                System.Console.WriteLine(allColumns.Count);



            }


        }
    }
}
