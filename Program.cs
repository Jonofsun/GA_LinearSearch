using static System.Formats.Asn1.AsnWriter;

namespace GA_LinearSearch
{
    internal class Program
    {
        /* Jonathan Reed 
         * 1/10/24
         */
        // Declare the global arrays
        static string[] storeDirectory;
        static string[] storeCategories;
        static Store[] stores;
        static string[] animeTitles;
        static string[] animeGenres;
        static int[] episodeCounts;
        static Anime[] animes;

        static void Main(string[] args)
        {
            Preload();

            // Displaying information about each anime
            //for (int i = 0; i < animeList.Length; i++)
            //{
            //    Console.WriteLine($"Title: {animeList[i].Title}");
            //    Console.WriteLine($"Genre: {animeList[i].Genre}");
            //    Console.WriteLine($"Episode Count: {animeList[i].EpisodeCount}");
            //    Console.WriteLine();
            //}

            Console.WriteLine("Contains");
            Console.WriteLine(ContainsStore(storeDirectory, "Aqua Adventures").ToString()); // True
            Console.WriteLine(ContainsStore(storeDirectory, "Box Lunch").ToString()); // False

            Console.WriteLine("Store By Index");
            Console.WriteLine(StoreByCategory(storeCategories, "Entertainment").ToString()); // 1
            Console.WriteLine(StoreByCategory(storeCategories, "Food").ToString()); // -1

            Console.WriteLine("All stores of a category");
            Console.WriteLine(AllStoresOfACategory(storeCategories, "Café & Bakery").Count); // 2
            Console.WriteLine(AllStoresOfACategory(storeCategories, "Food").Count); // 0

            Console.WriteLine("All stores on a floor");
            List<Store> storeResults = AllStoresOnLevel(stores, "A");
            Console.WriteLine(storeResults.Count); // 4
            foreach(Store store in storeResults) { Console.WriteLine($"{store.Name} - {store.StoreLocation}"); }
            Console.WriteLine(AllStoresOnLevel(stores, "E").Count); // 0

            //------------------------------------------------------------Anime-------------------------------------------------------------

            Console.WriteLine("Contains an Anime");
            Console.WriteLine(ContainsAnime(animeTitles, "One Piece").ToString()); // True
            Console.WriteLine(ContainsAnime(animeTitles, "Mushoku Tensei").ToString()); // False

            Console.WriteLine("Anime By Index");
            Console.WriteLine(AnimeByTitle(animeTitles, "Attack on Titan").ToString()); // 1
            Console.WriteLine(AnimeByTitle(animeTitles, "Re:Zero").ToString()); // -1
            Console.WriteLine("All Anime of a Genre");
            Console.WriteLine(AllAnimeOfAGenre(animeGenres, "Adventure").Count); // shows 2 as there are two anime that have that genre
            Console.WriteLine(AllAnimeOfAGenre(animeGenres, "Ecchi").Count); // 0 genre does not exist
            Console.WriteLine("All Anime with an episode count");
            List<Anime> animeResults = AllAnimeWithEpisodeCount(animes, 1000); // one piece actually has 1089 aired episodes with like 9 movies
            Console.WriteLine(animeResults.Count);
            foreach(Anime anime in animeResults) { Console.WriteLine($"{anime.Title} - {anime.Genre}"); }
            Console.WriteLine(AllAnimeWithEpisodeCount(animes, 24).Count); // printing to the console



        }

        public static bool ContainsStore(string[] storeList, string searchKey)
        {
            foreach (string store in storeList)
            {
                if (store == searchKey) // looping through the key and compairing the passed in information
                {
                    return true;
                }
            }
            return false;
        }

        public static int StoreByCategory(string[] storeList, string searchKey)
        {
            for (int i = 0; i < storeList.Length; i++)
            {
                if (storeList[i] == searchKey) // uses key to compair the passed in value
                {
                    return i;
                }
            }
            return -1; // Return -1 if not found
        }

        public static List<int> AllStoresOfACategory(string[] storeList, string searchKey)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < storeList.Length; i++) 
            {
                if (storeCategories[i] == searchKey) // runs the search key
                {
                    indices.Add(i);
                }
            }
            return indices;
        }

        public static List<Store> AllStoresOnLevel(Store[] storeList, string searchKey)
        {
            List<Store> storesInCategory = new List<Store>(); // adds new list information to memory 
            foreach (Store store in storeList)
            {
                if (store.StoreLocation[0].ToString() == searchKey)
                {
                    storesInCategory.Add(store); 
                }
            }
            return storesInCategory;
        }

        public static bool ContainsAnime(string[] animeTitles, string searchKey)
        {
            foreach (string title in animeTitles)
            {
                if (title == searchKey) // uses key to compair the passed in value and return a bool
                {
                    return true;
                }
            }
            return false;
        }

        public static int AnimeByTitle(string[] animeTitles, string searchKey)
        {
            for (int i = 0; i < animeTitles.Length; i++)
            {
                if (animeTitles[i] == searchKey) // uses key to compair the passed in value and return an int
                {
                    return i;
                }
            }
            return -1; // Return -1 if not found
        }

        public static List<int> AllAnimeOfAGenre(string[] animeGenres, string searchKey)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < animeGenres.Length; i++)
            {
                if (animeGenres[i] == searchKey) // uses key to compair the passed in value and prints the objects that match
                {
                    indices.Add(i);
                }
            }
            return indices;
        }

        public static List<Anime> AllAnimeWithEpisodeCount(Anime[] animeList, int searchKey)
        {
            List<Anime> animeWithEpisodeCount = new List<Anime>();
            foreach (Anime anime in animeList)
            {
                if (anime.EpisodeCount == searchKey) // uses key to compair the passed in value and returns the new List object
                {
                    animeWithEpisodeCount.Add(anime);
                }
            }
            return animeWithEpisodeCount;
        }

        static void Preload()
        {
            storeDirectory = new string[]
            {
            "Aqua Adventures",
            "Pixel Playhouse",
            "Brew & Bean",
            "Vintage Visions",
            "Garden Gateway",
            "Melody Makers",
            "Spice Spectrum",
            "Tech Trends",
            "Cozy Corner",
            "Frosty Delights"
            };

            storeCategories = new string[]
            {
            "Sports & Recreation",      // Aqua Adventures
            "Entertainment",            // Pixel Playhouse
            "Café & Bakery",            // Brew & Bean
            "Clothing & Accessories",   // Vintage Visions
            "Home & Garden",            // Garden Gateway
            "Entertainment",            // Melody Makers
            "Food & Groceries",         // Spice Spectrum
            "Electronics",              // Tech Trends
            "Home & Garden",            // Cozy Corner
            "Café & Bakery"             // Frosty Delights
            };

            stores = new Store[]
            {
            new Store("Aqua Adventures", "Sports & Recreation", "A21"),
            new Store("Pixel Playhouse", "Entertainment", "B7"),
            new Store("Brew & Bean", "Café & Bakery", "C36"),
            new Store("Vintage Visions", "Clothing & Accessories", "A9"),
            new Store("Garden Gateway", "Home & Garden", "B42"),
            new Store("Melody Makers", "Entertainment", "C15"),
            new Store("Spice Spectrum", "Food & Groceries", "A3"),
            new Store("Tech Trends", "Electronics", "B28"),
            new Store("Cozy Corner", "Home & Garden", "C12"),
            new Store("Frosty Delights", "Café & Bakery", "A31")
            };

            animeTitles = new string[]
            { 
                "One Piece",
                "Attack on Titan",
                "Naruto",
                "Death Note"
            };

            animeGenres = new string[]
            { 
                "Adventure",
                "Action",
                "Adventure",
                "Mystery"
            };

            episodeCounts = new int[]
            { 
                1000,
                75,
                220,
                37
            };

            animes = new Anime[animeTitles.Length];

            for (int i = 0; i < animeTitles.Length; i++) // fancy way to add values into the object
            {
                animes[i] = new Anime(animeTitles[i], animeGenres[i], episodeCounts[i]);
            }
        } // End Preload

    }
}
