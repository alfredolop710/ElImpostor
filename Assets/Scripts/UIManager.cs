using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class UIManager : MonoBehaviour
{
    [Header("Configuración de juego")]
    public TextMeshProUGUI jugadoresText;
    public TextMeshProUGUI impostoresText;
    public TMP_Dropdown temaDropdown;
    public TMP_Dropdown temaDropdownEn;
    public GameObject botonSiguiente;
    public GameObject textoErrorJugadores;
    public GameObject textoErrorImpostores;
    public GameObject menuComoJugar;
    private int jugadores;
    private int impostores;

    private Dictionary<string, List<string>> temasPalabras = new Dictionary<string, List<string>>()
    {
        { "Animales", new List<string> { "Elefante", "Tigre", "Perro", "Gato", "Ballena", "Águila", "León", "Pingüino", "Cebra", "Jirafa",
            "Caballo", "Cerdo", "Vaca", "Pulpo", "Salmón", "Tiburón", "Gallina", "Paloma", "Oso", "Mono",
            "Rana", "Puma", "Hipopótamo", "Rinoceronte", "Medusa", "Pato", "Lobo", "Avestruz", "Cocodrilo", "Canguro"} },
        { "Frutas", new List<string> { "Manzana", "Plátano", "Pera", "Sandía", "Melón", "Kiwi", "Mango", "Fresa", "Uva", "Piña",
            "Melocotón", "Coco", "Naranja", "Mandarina", "Limón", "Aguacate", "Mora", "Frambuesa", "Cereza", "Arándano" } },
        { "Países", new List<string> { "China", "México", "India", "Japón", "EEUU", "Reino Unido", "España", "Canadá", "Francia", "Egipto",
            "Italia", "Grecia", "Brasil", "Marruecos", "Suiza", "Alemania", "Rusia", "Perú", "Finlandia", "Islandia" } },
        { "Videojuegos", new List<string> { "GTA", "Minecraft", "Fortnite", "FIFA", "Tetris", "Red Dead Redemption", "Pokémon", "Digimón", "Super Mario", "Valorant",
            "Rocket League", "Mario Kart", "Pac-Man", "PUBG", "COD", "Zelda", "Wii Sports", "Assassin´s Creed", "Final Fantasy", "Kingdom Hearts",
            "TLOU", "God of War", "Metal Gear Solid", "Mafia", "Cyberpunk 2077", "Resident Evil", "No Man´s Sky", "Battlefield", "Elden Ring", "Dark Souls" } },
        { "Vehículos", new List<string> { "Coche", "Moto", "Camión", "Avión", "Barco", "Bicicleta", "Excabadora", "Avioneta", "Moto de Agua", "Monopatin",
            "Patinete", "Limusina", "Autobús", "Tren", "Carabana", "Carrito de Golf", "Furgoneta", "Hélice", "Motor", "Lamborghini" } },
        { "Deportes", new List<string> { "Baloncesto", "Fútbol", "Badmintón", "Voleyball", "Golf", "Tenis", "Pádel", "Formula 1", "Atletismo", "Hockey",
            "Ciclismo", "Natación", "Waterpolo", "Surf", "Esquí", "Boxeo", "Judo", "Balonmano", "Rugby", "Béisbol",
            "Petanca", "Halterofilia", "Ajedrez", "Billar", "Salto de longitud", "Salto de vallas", "Piragüismo", "Vela", "Triatlón", "Lanzamiento de disco" } },
        { "Comidas", new List<string> { "Paella", "Tortilla Patatas", "Cocido", "Lentejas", "Alitas de Pollo", "Perrito Caliente", "Hamburguesa", "Macarrones", "Spaghetti", "Cachopo",
            "Arroz 3 Delicias", "Rollito Primavera", "Ensalada", "Sopa", "Entrecot", "Pizza", "Champiñones", "Judías Verdes", "Judías Blancas", "Croquetas",
            "Albóndigas", "Pulpo a la Gallega", "Sandwich", "Patatas Fritas", "Nachos", "Burritos", "Kebab", "Sushi", "Galletas", "Tarta de queso" } },
        { "Juegos y juguetes", new List<string> { "Jenga", "Monopoly", "Trivial", "Ajedrez", "UNO", "Pictionary", "Bingo", "Poker", "Cluedo", "Quien es Quien",
            "Coche Teledirigido", "Canicas", "Oca", "Parchís", "3 en Raya", "Dominó", "Basta/Scattegories", "Scrabble", "Solitario", "Backgammon",
            "Scalextric", "Barbie", "Nerf", "Hot Wheels", "Operación", "Peluches", "Pelota", "Playmovil", "Lego", "Tamagotchi",
            "Bakugan", "Pokemon", "Puzle", "Damas", "Cartas contra la humanidad", "Cubo de Rubik", "Robot", "Dardos", "Billar", "Futbolín" } },
        { "Películas", new List<string> { "El Padrino", "Los Vengadores", "Avatar", "Titanic", "Star Wars", "Jurassic Park", "Fast & Furius", "Harry Potter", "Toy Story", "Cars",
            "Piratas del Caribe", "Buscando a Nemo", "El Señor de los Anillos", "Shrek", "Spider-Man", "Ice Age", "Crepúsculo", "Los Juegos del Hambre", "Gru: mi Villano Favorito", "El Rey León",
            "Blancanieves", "Cenicienta", "La Sirenita", "Jumanji", "La Bella Durmiente", "Frozen", "La Bella y la Bestia", "ET: el Extraterrestre", "101 Dalmatas", "Tiburón",
            "El Exorcista", "Rec", "Expediente Warren", "Regreso al Futuro", "Indiana Jones", "Misión Imposible", "Rocky", "Terminator", "2001: Una Odisea en el Espacio", "Interestelar",
            "300", "Peter pan", "La Dama y el Vagabundo", "El Silencio de los Corderos", "Los Increibles", "Dune", "Alien vs Predator", "Saw", "Monstruos S.A.", "Los Cazafantasmas" } },
        { "Series", new List<string> { "Los Simpson", "Padre de Familia", "Miercoles", "La Casa de Papel", "Inazuma Eleven", "Oliver y Benji", "Dragon Ball", "Naruto", "One Piece", "Bob Esponja",
            "Billy y Mandy", "Breaking Bad", "Stranger Things", "Juego de Tronos", "Vikingos", "The Boys", "Friends", "The Office", "Narcos", "Prison Break",
            "Modern Family", "2 Hombres y Medio", "Big Bang Theory", "Aqui no hay Quien Viva", "La que se Avecina", "Doraemon", "Castle", "The Walking Dead", "Peaky Blinders", "Codigo Lyoko",
            "Pokémon", "Bakugan", "Digimon", "Caillou", "Las Supernenas", "Pocoyo", "Peppa Pig", "Scooby Doo", "iCarly", "Lazy Town" } },
        { "Disney", new List<string> { "Blancanieves", "Frozen", "La bella y la Bestia", "La Sirenita", "Cenicienta", "Dumbo", "Bambi", "Aladín", "Mulan", "Pocahontas",
            "101 Dalmatas", "Pinocho", "Rapunzel", "Tiana y el sapo", "Campanilla", "Moana", "Anna", "Olaf", "Castillo de Disney", "Mickey Mouse",
            "Pato Donald", "Pluto", "Goofie", "Peter Pan", "Stitch", "El Rey León", "Tarzán", "Jafar", "Maléfica", "Capitán Garfio"} },
        { "Lugares", new List<string> { "Comisaría", "Bar", "Cafetería", "Tienda de Chuches", "Peluquería", "Farmacia", "Hospital", "Estación de Bomberos", "Supermercado", "Centro Comercial",
            "Tienda de Ropa", "Casa", "Rascacielos", "Lago", "Playa", "Rio", "Banco", "Parque", "Parque de Atracciones", "Bolera",
            "Campo de Golf", "Puerto", "Aeropuerto", "Fábrica", "Papelería", "Hotel", "Aparcamiento", "Ferretería", "El Chino", "Droguería",
            "Empire State", "Taj Majal", "Big Ben", "Sagrada Familia", "Metro", "Estación de Tren", "Montaña", "Acueducto de Segovia", "Torre Eiffel", "Biblioteca",
            "Torre de Pisa", "Piramides de Egipto", "Estatua de la Libertad", "Gran Muralla China", "Burj Khalifa", "Venecia", "Machu Pichu", "Torre de Tokio", "Museo de Louvre", "Cristo Redentor",
            "Isla de Pascua", "Stonehenge", "Gran Cañon", "Las Vegas", "Cataratas del Niagara", "Golden Gate", "Caribe", "Monte Fuji", "Barrio de Akihabara", "La Alhambra",
            "Hollywood", "Times Square", "Area 51", "Monte Rushmore", "DisneyLand", "Central Park", "Hawai", "Desierto del Sahara", "Oceanografic", "Capitolio de Washington"} },
        { "Super Heroes y Villanos", new List<string> { "Iron Man", "Capitan America", "Hulk", "Thor", "AntMan", "SpiderMan", "Batman", "Superman", "Linterna Verde", "DeadPool",
            "Wolverine", "Daredevil", "Bruja Escarlata", "Aquaman", "Visión", "Ojo de Halcon", "Black Widow", "Gamora", "Star-Lord", "Thanos",
            "Galactus", "Ronin", "Loki", "Peacemaker", "Groot", "Dr Doom", "Los 4 Fantásticos", "Joker", "Wonder Woman", "Harley Quinn"} },
        { "Marcas", new List<string> { "Fanta", "Coca Cola", "Nestea", "McDonalds", "Burger King", "KFC", "Android", "Apple", "Master Card", "Visa",
            "Toyota", "Renault", "Ferrari", "Lamborghini", "Harley Davidson", "Facebook", "Tuenti", "Twitter", "Instagram", "PlayStation",
            "XBox", "Nintendo", "Monster", "Red Bull", "Amazon", "Lego", "Samsung", "Xiaomi", "Repsol", "Tesla",
            "Pokémon", "Google", "Zara", "Starbucks", "Adidas", "Sprite", "Disney", "Microsoft", "Ikea", "Netflix",
            "Nescafe", "Mahou", "Kellogg´s", "Colgate", "Ebay", "PayPal", "Jack Daniels", "Brugal", "UPS", "MSI" } },
        { "Cosas de casa", new List<string> { "Cama", "Armario", "Habitación", "Baño", "Cocina", "Terraza", "Bañera", "Inodoro", "Bidé", "Lavabo",
            "Sofa", "Litera", "Sillón", "Televisión", "Ordenador", "Mesita de Noche", "Silla", "Mesa", "Zapatero", "Entrada",
            "Pasillo", "Isla", "Fregadero", "Microondas", "Frigorífico", "Lavadora", "Lavavajillas", "Secadora", "Congelador", "Cajones",
            "Cortinas", "Puerta", "Ventana", "Perchero", "Enchufe", "Cuadro", "Cocina de gas", "Vitrocerámica", "Freidora", "Tostadora",
            "Sandwichera", "Sarten", "Cazo", "Fregona", "Recogedor", "Escoba", "Mopa", "Trapo", "Radiador", "Cafetera" } },
        { "Profesiones", new List<string> { "Bombero", "Policía", "Informático", "Dependiente", "Camarero", "Asesor", "Político", "Banquero", "Cocinero", "Hotelero",
            "Futbolista", "Vendedor Ambulante", "Recepcionista", "Oficinista", "Profesor", "Director", "Cantante", "Bailarín", "Médico", "Enfermero",
            "Chofer", "Conductor de Buses", "Electricista", "Fontanero", "Periodista", "Taxista", "Fotógrafo", "Piloto", "Azafata", "Astronauta",
            "Abogado", "Arquitecto", "Obrero", "Diseñador", "Modelo", "Secretario", "Peluquero", "Florista", "Fisioterapeuta", "Psicólogo"} },
        { "Grupos de Música", new List<string> { "NO:ERA", "Nirvana", "Queen", "Iron Maiden", "Metallica", "System of a Down", "Mötley Crüe", "Los Beatles", "Rolling Stones", "AC/DC",
            "Guns n Roses", "Coldplay", "DragonForce", "Morat", "Avenged Sevenfold", "Green Day", "Mago de Oz", "Linkin Park", "Europe", "Evanescence",
            "Silverchair", "Imagine Dragons", "El canto del Loco", "Estopa", "La Oreja de Van Gogh", "Efecto Pasillo", "Maneskin", "Amaral", "Camela", "BTS",
            "One Direction", "Jonas Brothers", "Jackson 5", "Backstreet Boys", "Led Zeppelin", "Aerosmith", "Kiss", "Motorhead", "Korn", "Red Hot Chili Peppers"} },
        { "Ciudades del Mundo", new List<string> { "Madrid", "Barcelona", "Toledo", "Sevilla", "A Coruña", "Lisboa", "Berlín", "París", "Nueva York", "Los Ángeles",
            "Toronto", "Granada", "Londres", "Tokio", "Osaka", "Pekín", "Sidney", "Hong Kong", "Amsterdam", "San Francisco",
            "Washington", "Venecia", "Tenerife", "Philadelphia", "Bilbao", "Cuenca", "Buenos Aires", "Ciudad de Mexico", "Medellín", "Río de Janeiro",
            "Bogotá", "Sao Paulo", "Lima", "Santiago de Chile", "Santiago de Compostela", "Moscu", "Kiev", "El Cairo", "Dubai", "Roma"} },
        { "Personajes Famosos", new List<string> { "Pau Gasol", "Fernando Alonso", "Rafa Nadal", "Donald Trump", "Jeff Bezos", "Pedro Sánchez", "Jesucristo", "Napoleón", "Nikola Tesla", "Hitler",
            "Picasso", "Dalí", "Leonardo DiCaprio", "La Roca", "John Cena", "Morgan Freeman", "Sidney Sweeney", "Willem Dafoe", "Brad Pitt", "Tom Hanks",
            "Elvis Presley", "Galileo Galilei", "Newton", "Mahoma", "Will Smith", "Reyes Catolicos", "Einstein", "Gal Gadot", "El Cigala", "Pablo Motos",
            "Arnold Schwarzenegger", "Kiko Ribera", "Margot Robbie", "Marilyn Monroe", "Freddie Mercury", "Ilia Topuria", "Jordi ENP", "Vladimir Putin", "Keanu Reeves", "Tom Holland",
            "Carlos Arguiñano", "Steve Jobs", "Julio Cesar", "Vin Diesel", "Jim Carrey", "Henry Cavill", "Robert Downey Jr", "Chris Evans", "Chris Hemsworth", "Cristobal Colón",
            "Miguel de Cervantes", "El Greco", "Gaudí", "Charles Chaplin", "Iker Casillas", "Messi", "Cristiano Ronaldo", "IlloJuan", "Ibai", "TheGrefg",
            "Rubius", "Mbappe", "Mariano Rajoy", "El Papa", "Barack Obama", "Walt Disney", "Antonio Banderas", "Taylor Swift", "Tom Cruise", "Julio Iglesias"} },
        { "Personajes Ficticios", new List<string> { "Bob Esponja", "Harry Potter", "Ash Ketchum", "Pikachu", "Charizard", "Mickey Mouse", "Bugs Bunny", "Pluto", "Pato Donald", "Pantera Rosa",
            "Jack Sparrow", "Rocky Balboa", "Homer Simpson", "Batman", "Harley Quinn", "Mr. Bean", "Dora la Exploradora", "Peter Griffin", "Spiderman", "Las Supernenas",
            "Papa Pitufo", "Kim Posible", "Yoda", "Bart Simpson", "Mark Evans", "Axel Blaze", "Mordecai y Rigby", "Phineas y Ferb", "Jake el Perro", "Willy Wonka",
            "Jack(Titanic)", "Terminator", "Toretto", "Vito Corleone", "Epi y Blas", "Shrek", "Goku", "Naruto", "Luffy", "Pou",
            "Sonic", "Mario Bros", "Indiana Jones", "Gollum", "Tortugas Ninja", "Frankestein", "Jason Voorhees", "Freddy Krueger", "El Gato con Botas", "Pedro Picapiedra",
            "Scooby-Doo", "Sheldon Cooper", "Barbie", "Princesa Fiona", "Mortadelo", "Filemón", "Winnie the Pooh", "Pennywise", "Forest Gump", "Peter Pan",
            "James Bond", "Darth Vader", "Hannibal Lecter", "Beetlejuice", "Mazinger Z", "Draco Malfoy", "Voldemort", "Godzilla", "King Kong", "Superman" } },
        { "Artistas Internacionales", new List<string> { "Taylor Swift", "Rosalía", "Drake", "The Weeknd", "Bad Bunny", "Ariana Grande", "Melendi", "Quevedo", "Rihanna", "Bob Dylan",
            "Elvis Presley", "John Lennon", "David Bowie", "Bruce Springsteen", "Freddy Mercury", "Bob Marley", "Michael Jackson", "Madonna", "Jimi Hendrix", "Stevie Wonder",
            "Dr. Dre", "Snoop Dogg", "Kurt Cobain", "Bruno Mars", "Lady Gaga", "Billie Eilish", "Coldplay", "Ed Sheeran", "David Guetta", "Justin Bieber",
            "Eminem", "Dua Lipa", "Post Malone", "Ozzy Osbourne", "Martin Garrix", "Timmy Trumpet", "50Cent", "Daddy Yankee", "Avril Lavigne", "Beyoncé",
            "Britney Spears", "Bon Jovi", "Shakira", "Chayanne", "Christina Aguilera", "Chuck Berry", "Daft Punk", "Enrique Iglesias", "Julio Iglesias", "Eros Ramazzotti",
            "Frank Sinatra", "Jennifer Lopez", "Justin Timberlake", "Kanye West", "El Sevilla", "Laura Pausini", "Mariah Carey", "Miley Cyrus", "Paulina Rubio", "Ricky Martin",
            "Robbie Williams", "Travis Scott", "Maroon 5", "Adele", "Karol G", "Marshmello", "Rauw Alejandro", "XXXTentacion", "Selena Gómez", "Avicii" } },
    };

    private Dictionary<string, List<string>> temasPalabrasEn = new Dictionary<string, List<string>>()
    {
        { "Animals", new List<string> { "Elephant", "Tiger", "Dog", "Cat", "Whale", "Eagle", "Lion", "Penguin", "Zebra", "Giraffe",
            "Horse", "Pig", "Cow", "Octopus", "Salmon", "Shark", "Hen", "Pigeon", "Bear", "Monkey",
            "Frog", "Puma", "Hippo", "Rhino", "Jellyfish", "Duck", "Wolf", "Ostrich", "Crocodile", "Kangaroo"} },
        { "Fruits", new List<string> { "Apple", "Banana", "Pear", "Watermelon", "Melon", "Kiwi", "Mango", "Strawberry", "Grape", "Pineapple",
            "Peach", "Coconut", "Orange", "Tangerine", "Lemon", "Avocado", "Blackberry", "Raspberry", "Cherry", "Blueberry" } },
        { "Countries", new List<string> { "China", "Mexico", "India", "Japan", "EEUU", "United Kingdom", "Spain", "Canada", "France", "Egypt",
            "Italy", "Greece", "Brasil", "Moroco", "Switzerland", "Germany", "Russia", "Peru", "Finland", "Iceland" } },
        { "Videogames", new List<string> { "GTA", "Minecraft", "Fortnite", "FIFA", "Tetris", "Red Dead Redemption", "Pokémon", "Digimon", "Super Mario", "Valorant",
            "Rocket League", "Mario Kart", "Pac-Man", "PUBG", "COD", "Zelda", "Wii Sports", "Assassin´s Creed", "Final Fantasy", "Kingdom Hearts",
            "TLOU", "God of War", "Metal Gear Solid", "Mafia", "Cyberpunk 2077", "Resident Evil", "No Man´s Sky", "Battlefield", "Elden Ring", "Dark Souls" } },
        { "Vehicles", new List<string> { "Car", "Motorcycle", "Truck", "Plane", "Boat", "Bicycle", "Excavator", "Light Aircraft", "Jet Ski", "Skateboard",
            "Scooter", "Limousine", "Bus", "Train", "Carabana", "Golf cart", "Van", "Propeller", "Engine", "Lamborghini" } },
        { "Sports", new List<string> { "Basketball", "Football", "Badminton", "Voleyball", "Golf", "Tennis", "Padel", "Formula 1", "Athletics", "Hockey",
            "Cycling", "Swimming", "Waterpolo", "Surf", "Ski", "Boxing", "Judo", "Handball", "Rugby", "Baseball",
            "Petanque", "Weightlifting", "Chess", "Billiards", "Long jump", "Hurdling", "Canoeing", "Sailing", "Triathlon", "Discus throw" } },
        { "Foods", new List<string> { "Paella", "Spanish Omelet", "Stew", "Lentils", "Chicken Wings", "Hot Dog", "Hamburger", "Macaroni", "Spaghetti", "Cachopo",
            "3 Delights Rice", "Spring Roll", "Salad", "Soup", "Entrecôte", "Pizza", "Mushrooms", "Green Beans", "White Beans", "Croquettes",
            "Meatballs", "Galician-style Octopus", "Sandwich", "French Fries", "Nachos", "Burritos", "Kebab", "Sushi", "Cookies", "Cheesecake" } },
        { "Games & Toys", new List<string> { "Jenga", "Monopoly", "Trivial", "Chess", "UNO", "Pictionary", "Bingo", "Poker", "Cluedo", "Who is Who",
            "Remote Control Car", "Marbles", "Snakes & Ladders", "Parcheesi", "Tic-Tac-Toe", "Dominoes", "Scattegories", "Scrabble", "Solitaire", "Backgammon",
            "Scalextric", "Barbie", "Nerf", "Hot Wheels", "Operation", "Teddies", "Ball", "Playmovil", "Lego", "Tamagotchi",
            "Bakugan", "Pokemon", "Puzzle", "Checkers", "Cards Against Humanity", "Rubik Cube", "Robot", "Darts", "Billiards", "Table Soccer" } },
        { "Movies", new List<string> { "The Godfather", "The Avengers", "Avatar", "Titanic", "Star Wars", "Jurassic Park", "Fast & Furius", "Harry Potter", "Toy Story", "Cars",
            "Pirates of the Caribbean", "Finding Nemo", "The lord of the Rings", "Shrek", "Spider-Man", "Ice Age", "Twilight", "The Hunger Games", "Despicable Me", "The Lion King",
            "Snow White", "Cinderella", "The Little Mermaid", "Jumanji", "Sleeping Beauty", "Frozen", "The Beauty and the Beast", "ET: the Extraterrestrial", "101 Dalmatians", "Jaws",
            "The Exorcist", "Rec", "The Conjuring", "Back to the Future", "Indiana Jones", "Mission: Impossible", "Rocky", "Terminator", "2001: A Space Odyssey", "Interestelar",
            "300", "Peter pan", "Lady and the Tramp", "The Silence of the Lambs", "The Incredibles", "Dune", "Alien vs Predator", "Saw", "Monsters, Inc", "Ghostbusters" } },
        { "Series", new List<string> { "The Simpsons", "Family Guy", "Wednesday", "Money Heist", "Inazuma Eleven", "Captain Tsubasa", "Dragon Ball", "Naruto", "One Piece", "SpongeBob SquarePants",
            "Billy & Mandy", "Breaking Bad", "Stranger Things", "Game of Thrones", "Vikings", "The Boys", "Friends", "The Office", "Narcos", "Prison Break",
            "Modern Family", "2 Men and a Half", "Big Bang Theory", "Aqui no hay Quien Viva", "La que se Avecina", "Doraemon", "Castle", "The Walking Dead", "Peaky Blinders", "Code: Lyoko",
            "Pokémon", "Bakugan", "Digimon", "Caillou", "The Powerpuff Girls", "Pocoyo", "Peppa Pig", "Scooby Doo", "iCarly", "Lazy Town" } },
        { "Disney", new List<string> { "Snow White", "Frozen", "The Beauty and the Beast", "The Little Mermaid", "Cinderella", "Dumbo", "Bambi", "Aladdin", "Mulan", "Pocahontas",
            "101 Dalmatians", "Pinnochio", "Rapunzel", "The Princess and the Frog", "Tinkerbell", "Moana", "Anna", "Olaf", "Disney Castle", "Mickey Mouse",
            "Donald Duck", "Pluto", "Goofie", "Peter Pan", "Stitch", "The Lion King", "Tarzan", "Jafar", "Maleficent", "Captain Hook"} },
        { "Places", new List<string> { "Police station", "Bar", "Coffee shop", "Candy Store", "Hair Salon", "Pharmacy", "Hospital", "Fire Station", "Supermarket", "Shopping Mall",
            "Clothing Store", "House", "Skyscraper", "Lake", "Beach", "River", "Bank", "Park", "Amusement Park", "Bowling alley",
            "Golf Course", "Port", "Airport", "Factory", "Stationery", "Hotel", "Parking", "Hardware Store", "El Chino", "Drugstore",
            "Empire State", "Taj Majal", "Big Ben", "Sagrada Familia", "Subway", "Train Station", "Mountain", "Aqueduct of Segovia", "Torre Eiffel", "Library",
            "Tower of Pisa", "Pyramids of Egypt", "Liberty Statue", "Great Wall", "Burj Khalifa", "Venecia", "Machu Pichu", "Tokyo Tower", "Louvre Museum", "Cristo Redentor",
            "Easter Island", "Stonehenge", "Great Canyon", "Las Vegas", "Niagara Falls", "Golden Gate", "Caribean", "Mount Fuji", "Akihabara", "La Alhambra",
            "Hollywood", "Times Square", "Area 51", "Mount Rushmore", "DisneyLand", "Central Park", "Hawai", "Sahara Desert", "Oceanografic", "U.S. Capitol"} },
        { "Super Heroes y Villains", new List<string> { "Iron Man", "Capitain America", "Hulk", "Thor", "AntMan", "SpiderMan", "Batman", "Superman", "Green Lantern", "DeadPool",
            "Wolverine", "Daredevil", "Scarlet Witch", "Aquaman", "Vision", "Hawkeye", "Black Widow", "Gamora", "Star-Lord", "Thanos",
            "Galactus", "Ronin", "Loki", "Peacemaker", "Groot", "Dr Doom", "The Fantastic Four", "Joker", "Wonder Woman", "Harley Quinn"} },
        { "Brands", new List<string> { "Fanta", "Coca Cola", "Nestea", "McDonalds", "Burger King", "KFC", "Android", "Apple", "Master Card", "Visa",
            "Toyota", "Renault", "Ferrari", "Lamborghini", "Harley Davidson", "Facebook", "Tuenti", "Twitter", "Instagram", "PlayStation",
            "XBox", "Nintendo", "Monster", "Red Bull", "Amazon", "Lego", "Samsung", "Xiaomi", "Repsol", "Tesla",
            "Pokémon", "Google", "Zara", "Starbucks", "Adidas", "Sprite", "Disney", "Microsoft", "Ikea", "Netflix",
            "Nescafe", "Mahou", "Kellogg´s", "Colgate", "Ebay", "PayPal", "Jack Daniels", "Brugal", "UPS", "MSI" } },
        { "Home Things", new List<string> { "Bed", "Wardrobe", "Bedroom", "Bathroom", "Kitchen", "Terrace", "Bath", "WC", "Bidet", "Sink",
            "Sofa", "Bunk", "Armchair", "TV", "Computer", "Bedside Table", "Chair", "Table", "Shoerack", "House Entrance",
            "Hallway", "Kitchen Island", "Mirror", "Microwave", "Fridge", "Washing Machine", "Dishwasher", "Dryer", "Freezer", "Drawers",
            "Curtains", "Door", "Window", "Rack", "Plug", "Painting", "Gas Stove", "Ceramic Hob", "Deep Fryer", "Toaster",
            "Sandwich Maker", "Frying Pan", "Saucepan", "Mop", "Dustpan", "Broom", "Mop", "Rag", "Radiator", "Coffee maker" } },
        { "Professions", new List<string> { "Firefighter", "Police", "IT", "Shop assistant", "Waiter", "Advisor", "Politician", "Banker", "Chef", "Hotelier",
            "Soccer player", "Street Vendor", "Receptionist", "Office worker", "Professor", "Principal", "Singer", "Dancer", "Doctor", "Nurse",
            "Driver", "Bus Driver", "Electrician", "Plumber", "Journalist", "Taxi Driver", "Photographer", "Pilot", "Flight Attendant", "Astronaut",
            "Attorney", "Architect", "Worker", "Designer", "Model", "Secretary", "Hairdresser", "Florist", "Physical Therapist", "Psychologist"} },
        { "Music Groups", new List<string> { "NO:ERA", "Nirvana", "Queen", "Iron Maiden", "Metallica", "System of a Down", "Mötley Crüe", "Los Beatles", "Rolling Stones", "AC/DC",
            "Guns n Roses", "Coldplay", "DragonForce", "Morat", "Avenged Sevenfold", "Green Day", "Mago de Oz", "Linkin Park", "Europe", "Evanescence",
            "Silverchair", "Imagine Dragons", "El canto del Loco", "Estopa", "La Oreja de Van Gogh", "Efecto Pasillo", "Maneskin", "Amaral", "Camela", "BTS",
            "One Direction", "Jonas Brothers", "Jackson 5", "Backstreet Boys", "Led Zeppelin", "Aerosmith", "Kiss", "Motorhead", "Korn", "Red Hot Chili Peppers"} },
        { "World Cities", new List<string> { "Madrid", "Barcelona", "Toledo", "Sevilla", "A Coruña", "Lisboa", "Berlin", "Paris", "New York", "Los Angeles",
            "Toronto", "Granada", "London", "Tokio", "Osaka", "Pekin", "Sidney", "Hong Kong", "Amsterdam", "San Francisco",
            "Washington DC", "Venecia", "Tenerife", "Philadelphia", "Bilbao", "Cuenca", "Buenos Aires", "Mexico City", "Medellin", "Rio de Janeiro",
            "Bogota", "Sao Paulo", "Lima", "Santiago de Chile", "Santiago de Compostela", "Moscu", "Kiev", "El Cairo", "Dubai", "Roma"} },
        { "Famous People", new List<string> { "Pau Gasol", "Fernando Alonso", "Rafa Nadal", "Donald Trump", "Jeff Bezos", "Pedro Sánchez", "Jesus", "Napoleon", "Nikola Tesla", "Hitler",
            "Picasso", "Dali", "Leonardo DiCaprio", "La Roca", "John Cena", "Morgan Freeman", "Sidney Sweeney", "Willem Dafoe", "Brad Pitt", "Tom Hanks",
            "Elvis Presley", "Galileo Galilei", "Newton", "Mahoma", "Will Smith", "Reyes Catolicos", "Einstein", "Gal Gadot", "El Cigala", "Pablo Motos",
            "Arnold Schwarzenegger", "Kiko Ribera", "Margot Robbie", "Marilyn Monroe", "Freddie Mercury", "Ilia Topuria", "Jordi ENP", "Vladimir Putin", "Keanu Reeves", "Tom Holland",
            "Carlos Arguiñano", "Steve Jobs", "Julio Cesar", "Vin Diesel", "Jim Carrey", "Henry Cavill", "Robert Downey Jr", "Chris Evans", "Chris Hemsworth", "Cristobal Colon",
            "Miguel de Cervantes", "El Greco", "Gaudi", "Charles Chaplin", "Iker Casillas", "Messi", "Cristiano Ronaldo", "IlloJuan", "Ibai", "TheGrefg",
            "Rubius", "Mbappe", "Mariano Rajoy", "El Papa", "Barack Obama", "Walt Disney", "Antonio Banderas", "Taylor Swift", "Tom Cruise", "Julio Iglesias"} },
        { "Fictional Characters", new List<string> { "SpongeBob SquarePants", "Harry Potter", "Ash Ketchum", "Pikachu", "Charizard", "Mickey Mouse", "Bugs Bunny", "Pluto", "Donald Duck", "Pink Panther",
            "Jack Sparrow", "Rocky Balboa", "Homer Simpson", "Batman", "Harley Quinn", "Mr. Bean", "Dora the Explorer", "Peter Griffin", "Spiderman", "The Powerpuff Girls",
            "Papa Smurf", "Kim Posible", "Yoda", "Bart Simpson", "Mark Evans", "Axel Blaze", "Mordecai & Rigby", "Phineas & Ferb", "Jake the Dog", "Willy Wonka",
            "Jack(Titanic)", "Terminator", "Toretto", "Vito Corleone", "Epi & Blas", "Shrek", "Goku", "Naruto", "Luffy", "Pou",
            "Sonic", "Mario Bros", "Indiana Jones", "Gollum", "Ninja Turtles", "Frankestein", "Jason Voorhees", "Freddy Krueger", "Puss in Boots", "Pedro Picapiedra",
            "Scooby-Doo", "Sheldon Cooper", "Barbie", "Princess Fiona", "Mortadelo", "Filemon", "Winnie the Pooh", "Pennywise", "Forest Gump", "Peter Pan",
            "James Bond", "Darth Vader", "Hannibal Lecter", "Beetlejuice", "Mazinger Z", "Draco Malfoy", "Voldemort", "Godzilla", "King Kong", "Superman" } },
        { "International Artists", new List<string> { "Taylor Swift", "Rosalía", "Drake", "The Weeknd", "Bad Bunny", "Ariana Grande", "Melendi", "Quevedo", "Rihanna", "Bob Dylan",
            "Elvis Presley", "John Lennon", "David Bowie", "Bruce Springsteen", "Freddy Mercury", "Bob Marley", "Michael Jackson", "Madonna", "Jimi Hendrix", "Stevie Wonder",
            "Dr. Dre", "Snoop Dogg", "Kurt Cobain", "Bruno Mars", "Lady Gaga", "Billie Eilish", "Coldplay", "Ed Sheeran", "David Guetta", "Justin Bieber",
            "Eminem", "Dua Lipa", "Post Malone", "Ozzy Osbourne", "Martin Garrix", "Timmy Trumpet", "50Cent", "Daddy Yankee", "Avril Lavigne", "Beyoncé",
            "Britney Spears", "Bon Jovi", "Shakira", "Chayanne", "Christina Aguilera", "Chuck Berry", "Daft Punk", "Enrique Iglesias", "Julio Iglesias", "Eros Ramazzotti",
            "Frank Sinatra", "Jennifer Lopez", "Justin Timberlake", "Kanye West", "El Sevilla", "Laura Pausini", "Mariah Carey", "Miley Cyrus", "Paulina Rubio", "Ricky Martin",
            "Robbie Williams", "Travis Scott", "Maroon 5", "Adele", "Karol G", "Marshmello", "Rauw Alejandro", "XXXTentacion", "Selena Gómez", "Avicii" } },
    };


    private void Start()
    {
        jugadores = GameManager.Instance.totalJugadores;
        impostores = GameManager.Instance.totalImpostores;
        jugadoresText.text = jugadores.ToString();
        impostoresText.text = impostores.ToString();
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "es")
        {
            textoNombre.text = $"Ya se han agregado los jugadores, pulsa la pantalla para mostrar al jugador y vuelve a pulsarla para mostrar el rol.\r\nRecuerda no revelar tu rol a los demás";
        }
        else
        {
            textoNombre.text = $"The players have already been added. Tap the screen to display the player and tap again to display the role.\r\nRemember not to reveal your role to others.";
        }
    }


    public void MenosJugadores()
    {
        if (GameManager.Instance.jugadores.Count == 0 && jugadores > 3)
        {
            jugadores--;
            jugadoresText.text = jugadores.ToString();
        }
    }
    public void MasJugadores()
    {
        if (GameManager.Instance.jugadores.Count == 0)
        {
            jugadores++;
            jugadoresText.text = jugadores.ToString();
        }
    }
    public void MenosImpostores()
    {
        if (GameManager.Instance.jugadores.Count == 0 && impostores > 1)
        {
            impostores--;
            impostoresText.text = impostores.ToString();
        }
    }
    public void MasImpostores()
    {
        if (GameManager.Instance.jugadores.Count == 0 && impostores < jugadores - 1)
        {
            impostores++;
            impostoresText.text = impostores.ToString();
        }
    }
    public void GuardarConfiguracion()
    {
        if (jugadores < 3)
        {
            StartCoroutine(TextErrorJugador());
            return;
        }

        if (impostores < 1 || impostores >= jugadores)
        {
            StartCoroutine(TextErrorImpostor());
            return;
        }
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "es")
        {
            string temaSeleccionado = temaDropdown.options[temaDropdown.value].text;

            List<string> palabras = temasPalabras[temaSeleccionado];
            string palabraAleatoria = palabras[Random.Range(0, palabras.Count)];

            GameManager.Instance.totalJugadores = jugadores;
            GameManager.Instance.totalImpostores = impostores;
            GameManager.Instance.tema = temaSeleccionado;
            GameManager.Instance.palabra = palabraAleatoria;
        }
        else
        {
            string temaSeleccionado = temaDropdownEn.options[temaDropdownEn.value].text;

            List<string> palabras = temasPalabrasEn[temaSeleccionado];
            string palabraAleatoria = palabras[Random.Range(0, palabras.Count)];

            GameManager.Instance.totalJugadores = jugadores;
            GameManager.Instance.totalImpostores = impostores;
            GameManager.Instance.tema = temaSeleccionado;
            GameManager.Instance.palabra = palabraAleatoria;
        }
        
        if (jugadores >= 3 && (impostores >= 1 || impostores < jugadores))
        {
            botonSiguiente.SetActive(true);
        }

    }

    public void SeleccionarTemaAleatorio()
    {
        int randomIndex = Random.Range(0, temaDropdown.options.Count);
        temaDropdown.value = randomIndex;
        temaDropdownEn.value = randomIndex;
        temaDropdown.RefreshShownValue();
        temaDropdownEn.RefreshShownValue();
    }

    public void MenuComoJugarOn()
    {
        menuComoJugar.SetActive(true);
    }
    public void MenuComoJugarOff()
    {
        menuComoJugar.SetActive(false);
    }

    [Header("Registro de nombres")]
    public TMP_InputField nombreInput;
    public Transform listaJugadoresUI;
    public GameObject itemNombrePrefab;
    public GameObject botonJugar;

    public void AgregarNombre()
    {
        string nombre = nombreInput.text.Trim();
        if (!string.IsNullOrEmpty(nombre) && GameManager.Instance.nombres.Count < GameManager.Instance.totalJugadores)
        {
            GameManager.Instance.nombres.Add(nombre);
            var nuevoItem = Instantiate(itemNombrePrefab, listaJugadoresUI);
            nuevoItem.GetComponentInChildren<TextMeshProUGUI>().text = nombre;
            nombreInput.text = "";
        }
        if (GameManager.Instance.nombres.Count >= GameManager.Instance.totalJugadores)
        {
            botonJugar.SetActive(true);
            GameManager.Instance.GenerarJugadores();
        }
    }

    [Header("Mostrar roles")]
    public TextMeshProUGUI textoNombre;
    public TextMeshProUGUI textoRol;
    public GameObject nombreGameObject;
    public GameObject rolGameObject;
    public int indiceActual = 0;
    public GameObject imageBotonesFinales;
    public CardFlip cardPanel;
    public GameObject botonMostrarRol;
    private bool textoPrimero = true;

    public void MostrarSiguienteJugador()
    {
        if (textoPrimero)
        {
            
            textoPrimero = false;
        }
        if (indiceActual < GameManager.Instance.jugadores.Count)
        {
            StartCoroutine(SiguienteRol());
            StartCoroutine(QuitaBoton());
            /*if (textoPrimero == false)
            {
                
                
                if (rolGameObject.activeInHierarchy)
                {
                    nombreGameObject.SetActive(true);
                    rolGameObject.SetActive(false);
                }
                else
                {
                    nombreGameObject.SetActive(false);
                    rolGameObject.SetActive(true);
                    indiceActual++;
                }
            }
            else
            {
                var jugador = GameManager.Instance.jugadores[indiceActual];
                textoPrimero = false;
                textoNombre.text = $"Turno de:\n{jugador.nombre}";
            }*/
        }
        else
        {
            StartCoroutine(FinalRonda());
            /*cardPanel.FlipCard();
            textoNombre.text = "¡Todos han visto su rol!\nAhora pasen el móvil y comiencen la discusión.\nComienza " + GameManager.Instance.jugadores[Random.Range(0, GameManager.Instance.jugadores.Count)].nombre;
            textoRol.text = "¡Todos han visto su rol!\nAhora pasen el móvil y comiencen la discusión.\nComienza " + GameManager.Instance.jugadores[0].nombre;
            botonVolverJugar.SetActive(true);
            botonVolverMenu.SetActive(true);*/
        }
    }
    [Header("Volver a jugar")]
    public GameObject menuVolverMenu;
    public void VolverJugar()
    {
        menuVolverMenu.SetActive(true);
    }
    public void AtrasMenuVolverJugar()
    {
        menuVolverMenu.SetActive(false);
    }
    public void GuardarConfiguracionVolverAJugar()
    {
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "es") 
        {
            List<string> palabras = temasPalabras[GameManager.Instance.tema];
            string palabraAleatoria = palabras[Random.Range(0, palabras.Count)];
            GameManager.Instance.palabra = palabraAleatoria;
            GameManager.Instance.GenerarJugadores();
        }
        else
        {
            List<string> palabras = temasPalabrasEn[GameManager.Instance.tema];
            string palabraAleatoria = palabras[Random.Range(0, palabras.Count)];
            GameManager.Instance.palabra = palabraAleatoria;
            GameManager.Instance.GenerarJugadores();
        }
        
    }

    IEnumerator TextErrorJugador()
    {
        textoErrorJugadores.SetActive(true);
        yield return new WaitForSeconds(2);
        textoErrorJugadores.SetActive(false);
    }
    IEnumerator TextErrorImpostor()
    {
        textoErrorImpostores.SetActive(true);
        yield return new WaitForSeconds(2);
        textoErrorImpostores.SetActive(false);
    }
    IEnumerator SiguienteRol()
    {

        cardPanel.FlipCard();
        yield return new WaitForSeconds(cardPanel.flipDuration / 2f);
        var jugador = GameManager.Instance.jugadores[indiceActual];
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "es")
        {
            textoNombre.text = $"Turno de:\n{jugador.nombre}";
            textoRol.text = jugador.esImpostor
                ? $"ERES IMPOSTOR\n\nTema: {GameManager.Instance.tema}"
                : $"Palabra secreta:\n <b><color=#591884>{GameManager.Instance.palabra} </color></b>\nTema: {GameManager.Instance.tema}";
        }
        else
        {
            textoNombre.text = $"{jugador.nombre} turn";
            textoRol.text = jugador.esImpostor
                ? $"YOU ARE IMPOSTOR\n\nTopic: {GameManager.Instance.tema}"
                : $"Secret Word:\n <b><color=#591884>{GameManager.Instance.palabra} </color></b>\nTopic: {GameManager.Instance.tema}";
        }
        if (rolGameObject.activeInHierarchy)
        {
            nombreGameObject.SetActive(true);
            rolGameObject.SetActive(false);
        }
        else
        {
            nombreGameObject.SetActive(false);
            rolGameObject.SetActive(true);
            indiceActual++;
        }
    }
    IEnumerator QuitaBoton()
    {
        botonMostrarRol.SetActive(false);
        yield return new WaitForSeconds(cardPanel.flipDuration);
        botonMostrarRol.SetActive(true);
    }
    IEnumerator FinalRonda()
    {
        cardPanel.FlipCard();
        yield return new WaitForSeconds(cardPanel.flipDuration / 2f);
        AdManager.Instance.ShowInterstitialAd();
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "es")
        {
            textoNombre.text = "¡Todos han visto su rol!\nAhora dejad el movil y comenzad la discusión.\nComienza " + GameManager.Instance.jugadores[Random.Range(0, GameManager.Instance.jugadores.Count)].nombre;
            textoRol.text = "¡Todos han visto su rol!\nAhora dejad el movil y comenzad la discusión.\nComienza " + GameManager.Instance.jugadores[Random.Range(0, GameManager.Instance.jugadores.Count)].nombre;
        }
        else
        {
            textoNombre.text = "¡Everyone has seen their role!\nNow put down the phone and start the discussion.\n" + GameManager.Instance.jugadores[Random.Range(0, GameManager.Instance.jugadores.Count)].nombre + " starts";
            textoRol.text = "¡Everyone has seen their role!\nNow put down the phone and start the discussion.\n" + GameManager.Instance.jugadores[Random.Range(0, GameManager.Instance.jugadores.Count)].nombre + " starts";
        }
        botonMostrarRol.SetActive(false);
        imageBotonesFinales.SetActive(true);
    }
}
