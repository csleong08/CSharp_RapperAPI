using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        [Route("/artists")]
        [HttpGet]
        public string Artists() {
            string artists = "Here's a list of all the Artists\n";
            foreach (var item in allArtists)
            {
                artists += item.ArtistName + "\n";
            }
            return artists;
        }
        [Route("/artists/Name/{artist}")]
        [HttpGet]
        public string ArtistName(string artist) {
            string artistName = "Artist name search\n";
            var AName = allArtists.Where(p => p.ArtistName.Contains(artist));
            foreach (var item in AName)
            {
                artistName += item.ArtistName + "\n";
            }
            return artistName;
        }
        [Route("/artists/RealName/{name}")]
        [HttpGet]
        public string RealName(string name) {
            string RealName = "Real Name search\n";
            var RName = allArtists.Where(p => p.RealName.Contains(name));
            foreach (var item in RName)
            {
                RealName += item.RealName + "\n";
            }
            return RealName;
        }
        [Route("/artists/Hometown/{city}")]
        [HttpGet]
        public string City(string city) {
            string hometown = "Hometown Artists\n";
            var Hometown = allArtists.Where(p => p.Hometown == city);
            foreach (var item in Hometown)
            {
                hometown += item.ArtistName + "\n";
            }
            return hometown;
        }
        [Route("/artists/GroupId/{group}")]
        [HttpGet]
        public string GroupID(int group) {
            string ArtistByGroup = "Artists searched by Group ID\n";
            var artistByGroup = allArtists.Where(p => p.GroupId== group);
            foreach (var item in artistByGroup)
            {
                ArtistByGroup += item.ArtistName + "\n";
            }
            return ArtistByGroup;
        }
    }
}