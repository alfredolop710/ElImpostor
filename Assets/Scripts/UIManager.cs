using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Configuraci�n de juego")]
    public TextMeshProUGUI jugadoresText;
    public TextMeshProUGUI impostoresText;
    public TMP_Dropdown temaDropdown;
    public GameObject botonSiguiente;
    public GameObject textoErrorJugadores;
    public GameObject textoErrorImpostores;
    public GameObject menuComoJugar;
    private int jugadores;
    private int impostores;

    private Dictionary<string, List<string>> temasPalabras = new Dictionary<string, List<string>>()
    {
        { "Animales", new List<string> { "Elefante", "Tigre", "Perro", "Gato", "Ballena", "�guila", "Le�n", "Ping�ino", "Cebra", "Jirafa",
            "Caballo", "Cerdo", "Vaca", "Pulpo", "Salm�n", "Tibur�n", "Gallina", "Paloma", "Oso", "Mono",
            "Rana", "Puma", "Hipop�tamo", "Rinoceronte", "Medusa", "Pato", "Lobo", "Avestruz", "Cocodrilo", "Canguro"} },
        { "Frutas", new List<string> { "Manzana", "Pl�tano", "Pera", "Sand�a", "Mel�n", "Kiwi", "Mango", "Fresa", "Uva", "Pi�a",
            "Melocot�n", "Coco", "Naranja", "Mandarina", "Lim�n", "Aguacate", "Mora", "Frambuesa", "Cereza", "Ar�ndano" } },
        { "Paises", new List<string> { "China", "M�xico", "India", "Jap�n", "EEUU", "Reino Unido", "Espa�a", "Canad�", "Francia", "Egipto",
            "Italia", "Grecia", "Brasil", "Marruecos", "Suiza", "Alemania", "Rusia", "Per�", "Finlandia", "Islandia" } },
        { "Videojuegos", new List<string> { "GTA", "Minecraft", "Fortnite", "FIFA", "Tetris", "Red Dead Redemption", "Pok�mon", "Digim�n", "Super Mario", "Valorant",
            "Rocket League", "Mario Kart", "Pac-Man", "PUBG", "COD", "Zelda", "Wii Sports", "Assassin�s Creed", "Final Fantasy", "Kingdom Hearts",
            "TLOU", "God of War", "Metal Gear Solid", "Mafia", "Cyberpunk 2077", "Resident Evil", "No Man�s Sky", "Battlefield", "Elden Ring", "Dark Souls" } },
        { "Vehiculos", new List<string> { "Coche", "Moto", "Cami�n", "Avi�n", "Barco", "Bicicleta", "Excabadora", "Avioneta", "Moto de Agua", "Monopatin",
            "Patinete", "Limusina", "Autob�s", "Tren", "Carabana", "Carrito de golf", "Furgoneta", "H�lice", "Motor", "Lamborghini" } },
        { "Deportes", new List<string> { "Baloncesto", "F�tbol", "Badmint�n", "Voleyball", "Golf", "Tenis", "P�del", "Formula 1", "Atletismo", "Hockey",
            "Ciclismo", "Nataci�n", "Waterpolo", "Surf", "Esqu�", "Boxeo", "Judo", "Balonmano", "Rugbi", "B�isbol",
            "Petanca", "Halterofilia", "Ajedrez", "Billar", "Salto de longitud", "Salto de vallas", "Pirag�ismo", "Vela", "Triatl�n", "Lanzamiento de disco" } },
        { "Comidas", new List<string> { "Paella", "Tortilla Patatas", "Cocido", "Lentejas", "Alitas de Pollo", "Perrito Caliente", "Hamburguesa", "Macarrones", "Spaghetti", "Cachopo",
            "Arroz 3 Delicias", "Rollito Primavera", "Ensalada", "Sopa", "Entrecot", "Pizza", "Champi�ones", "Jud�as Verdes", "Jud�as Blancas", "Croquetas",
            "Alb�ndigas", "Pulpo", "Sandwich", "Patatas Fritas", "Nachos", "Burritos", "Kebab", "Sushi", "Galletas", "Tarta de queso" } },
        { "Juegos y juguetes", new List<string> { "Jenga", "Monopoly", "Trivial", "Ajedrez", "UNO", "Pictionary", "Bingo", "Poker", "Cluedo", "Quien es Quien",
            "Coche Teledirigido", "Canicas", "Oca", "Parch�s", "3 en Raya", "Domin�", "Basta/Scattegories", "Scrabble", "Solitario", "Backgammon",
            "Scalextrik", "Barbie", "Nerf", "Hot Wheels", "Operaci�n", "Peluches", "Pelota", "Playmovil", "Lego", "Tamagotchi",
            "Bakugan", "Pokemon", "Puzle", "Damas", "Cartas contra la humanidad", "Cubo de Rubik", "Robot", "Dardos", "Billar", "Futbol�n" } },
        { "Pel�culas", new List<string> { "El Padrino", "Los Vengadores", "Avatar", "Titanic", "Star Wars", "Jurassic Park", "Fast & Furius", "Harry Potter", "Toy Story", "Cars",
            "Piratas del Caribe", "Buscando a Nemo", "El Se�or de los Anillos", "Shrek", "Spider-Man", "Ice Age", "Crep�sculo", "Los Juegos del Hambre", "Gru: mi Villano Favorito", "El Rey Le�n",
            "Blancanieves", "Cenicienta", "La Sirenita", "Jumanji", "La Bella Durmiente", "Frozen", "La Bella y la Bestia", "ET: el Extraterrestre", "101 Dalmatas", "Tibur�n",
            "El Exorcista", "Rec", "Expediente Warren", "Regreso al Futuro", "Indiana Jones", "Misi�n Imposible", "Rocky", "Terminator", "2001: Una Odisea en el Espacio", "Interestelar",
            "300", "Peter pan", "La Dama y el Vagabundo", "El Silencio de los Corderos", "Los Increibles", "Dune", "Alien vs Predator", "Saw", "Monstruos S.A.", "Los Cazafantasmas" } },
        { "Series", new List<string> { "Los Simpson", "Padre de Familia", "Miercoles", "La Casa de Papel", "Inazuma Eleven", "Oliver y Benji", "Dragon Ball", "Naruto", "One Piece", "Bob Esponja",
            "Billy y Mandy", "Breaking Bad", "Stranger Things", "Juego de Tronos", "Vikingos", "The Boys", "Friends", "The Office", "Narcos", "Prison Break",
            "Modern Family", "2 Hombres y Medio", "Big Bang Theory", "Aqui no hay Quien Viva", "La que se Avecina", "Doraemon", "Castle", "The Walking Dead", "Peaky Blinders", "Codigo Lyoko",
            "Pok�mon", "Bakugan", "Digimon", "Caillou", "Las Supernenas", "Pocoyo", "Peppa Pig", "Scooby Doo", "iCarly", "Lazy Town" } },
        { "Disney", new List<string> { "Blancanieves", "Frozen", "La bella y la Bestia", "La Sirenita", "Cenicienta", "Dumbo", "Bambi", "Alad�n", "Mulan", "Pocahontas",
            "101 Dalmatas", "Pinocho", "Rapunzel", "Tiana y el sapo", "Campanilla", "Moana", "Anna", "Olaf", "Castillo de Disney", "Mickey Mouse",
            "Pato Donald", "Pluto", "Goofie", "Peter Pan", "Stitch", "El Rey Le�n", "Tarz�n", "Jafar", "Malefica", "Capit�n Garfio"} },
        { "Lugares", new List<string> { "Comisar�a", "Bar", "Cafeter�a", "Tienda de Chuches", "Peluquer�a", "Farmacia", "Hospital", "Estaci�n de Bomberos", "Supermercado", "Centro Comercial",
            "Tienda de Ropa", "Casa", "Rascacielos", "Lago", "Playa", "Rio", "Banco", "Parque", "Parque de Atracciones", "Bolera",
            "Campo de Golf", "Puerto", "Aeropuerto", "F�brica", "Papeler�a", "Hotel", "Aparcamiento", "Ferreter�a", "El Chino", "Droguer�a",
            "Empire State", "Taj Majal", "Big Ben", "Sagrada Familia", "Metro", "Estaci�n de Tren", "Monta�a", "Acueducto de Segovia", "Torre Eiffel", "Biblioteca",
            "Torre de Pisa", "Piramides de Egipto", "Estatua de la Libertad", "Gran Muralla China", "Burj Khalifa", "Venecia", "Machu Pichu", "Torre de Tokio", "Museo de Louvre", "Cristo Redentor",
            "Isla de Pascua", "Stonehenge", "Gran Ca�on", "Las Vegas", "Cataratas del Niagara", "Golden Gate", "Caribe", "Monte Fuji", "Barrio de Akihabara", "La Alhambra",
            "Hollywood", "Times Square", "Area 51", "Monte Rushmore", "DisneyLand", "Central Park", "Hawai", "Desierto del Sahara", "Oceanografic", "Capitolio de Washington"} },
        { "Super Heroes y Villanos", new List<string> { "Iron Man", "Capitan America", "Hulk", "Thor", "AntMan", "SpiderMan", "Batman", "Superman", "Linterna Verde", "DeadPool",
            "Wolverine", "Daredevil", "Bruja Escarlata", "Aquaman", "Visi�n", "Ojo de Halcon", "Black Widow", "Gamora", "Star-Lord", "Thanos",
            "Galactus", "Ronin", "Loki", "Peacemaker", "Groot", "Dr Doom", "Los 4 Fant�sticos", "Joker", "Wonder Woman", "Harley Quinn"} },
        { "Marcas", new List<string> { "Fanta", "Coca Cola", "Nestea", "McDonalds", "Burger King", "KFC", "Android", "Apple", "Master Card", "Visa",
            "Toyota", "Renault", "Ferrari", "Lamborghini", "Harley Davidson", "Facebook", "Tuenti", "Twitter", "Instagram", "PlayStation",
            "XBox", "Nintendo", "Monster", "Red Bull", "Amazon", "Lego", "Samsung", "Xiaomi", "Repsol", "Tesla",
            "Pok�mon", "Google", "Zara", "Starbucks", "Adidas", "Sprite", "Disney", "Microsoft", "Ikea", "Netflix",
            "Nescafe", "Mahou", "Kellogg�s", "Colgate", "Ebay", "PayPal", "Jack Daniels", "Brugal", "UPS", "MSI" } },
        { "Cosas de casa", new List<string> { "Cama", "Armario", "Habitaci�n", "Ba�o", "Cocina", "Terraza", "Ba�era", "Inodoro", "Bid�", "Lavabo",
            "Sofa", "Litera", "Sill�n", "Televisi�n", "Ordenador", "Mesita de noche", "Silla", "Mesa", "Zapatero", "Entrada",
            "Pasillo", "Isla", "Fregadero", "Microondas", "Frigor�fico", "Lavadora", "Lavavajillas", "Secadora", "Congelador", "Cajones",
            "Cortinas", "Puerta", "Ventana", "Perchero", "Enchufe", "Cuadro", "Cocina de gas", "Vitrocer�mica", "Freidora", "Tostadora",
            "Sandwichera", "Sarten", "Cazo", "Fregona", "Recogedor", "Escoba", "Mopa", "Trapo", "Radiador", "Cafetera" } },
        { "Profesiones", new List<string> { "Bombero", "Polic�a", "Inform�tico", "Dependiente", "Camarero", "Asesor", "Pol�tico", "Banquero", "Cocinero", "Hotelero",
            "Futbolista", "Vendedor Ambulante", "Recepcionista", "Oficinista", "Profesor", "Director", "Cantante", "Bailar�n", "M�dico", "Enfermero",
            "Chofer", "Conductor de Buses", "Electricista", "Fontanero", "Periodista", "Taxista", "Fot�grafo", "Piloto", "Azafata", "Astronauta",
            "Abogado", "Arquitecto", "Obrero", "Dise�ador", "Modelo", "Secretario", "Peluquero", "Florista", "Fisioterapeuta", "Psic�logo"} },
        { "Grupos de M�sica", new List<string> { "NO:ERA", "Nirvana", "Queen", "Iron Maiden", "Metallica", "System of a Down", "M�tley Cr�e", "Los Beatles", "Rolling Stones", "AC/DC",
            "Guns n Roses", "Coldplay", "DragonForce", "Morat", "Avenged Sevenfold", "Green Day", "Mago de Oz", "Linkin Park", "Europe", "Evanescence",
            "Silverchair", "Imagine Dragons", "El canto del Loco", "Estopa", "La Oreja de Van Gogh", "Efecto Pasillo", "Maneskin", "Amaral", "Camela", "BTS",
            "One Direction", "Jonas Brothers", "Jackson 5", "Backstreet Boys", "Led Zeppelin", "Aerosmith", "Kiss", "Motorhead", "Korn", "Red Hot Chili Peppers"} },
        { "Ciudades del Mundo", new List<string> { "Madrid", "Barcelona", "Toledo", "Sevilla", "A Coru�a", "Lisboa", "Berl�n", "Par�s", "Nueva York", "Los �ngeles",
            "Toronto", "Granada", "Londres", "Tokio", "Osaka", "Pek�n", "Sidney", "Hong Kong", "Amsterdam", "San Francisco",
            "Washington", "Venecia", "Tenerife", "Philadelphia", "Bilbao", "Cuenca", "Buenos Aires", "Ciudad de Mexico", "Medell�n", "R�o de Janeiro",
            "Bogot�", "Sao Paulo", "Lima", "Santiago de Chile", "Santiago de Compostela", "Moscu", "Kiev", "El Cairo", "Dubai", "Roma"} },
        { "Personajes Famosos", new List<string> { "Pau Gasol", "Fernando Alonso", "Rafa Nadal", "Donald Trump", "Jeff Bezos", "Pedro S�nchez", "Jesucristo", "Napole�n", "Nikola Tesla", "Hitler",
            "Picasso", "Dal�", "Leonardo DiCaprio", "La Roca", "John Cena", "Morgan Freeman", "Sidney Sweeney", "Willem Dafoe", "Brad Pitt", "Tom Hanks",
            "Elvis Presley", "Galileo Galilei", "Newton", "Mahoma", "Will Smith", "Reyes Catolicos", "Einstein", "Gal Gadot", "El Cigala", "Pablo Motos",
            "Arnold Schwarzenegger", "Kiko Ribera", "Margot Robbie", "Marilyn Monroe", "Freddie Mercury", "Ilia Topuria", "Jordi ENP", "Vladimir Putin", "Keanu Reeves", "Tom Holland",
            "Carlos Argui�ano", "Steve Jobs", "Julio Cesar", "Vin Diesel", "Jim Carrey", "Henry Cavill", "Robert Downey Jr", "Chris Evans", "Chris Hemsworth", "Cristobal Col�n",
            "Miguel de Cervantes", "El Greco", "Gaud�", "Charles Chaplin", "Iker Casillas", "Messi", "Cristiano Ronaldo", "IlloJuan", "Ibai", "TheGrefg",
            "Rubius", "Mbappe", "Mariano Rajoy", "El Papa", "Barack Obama", "Walt Disney", "Antonio Banderas", "Taylor Swift", "Tom Cruise", "Julio Iglesias"} },
        { "Personajes Ficticios", new List<string> { "Bob Esponja", "Harry Potter", "Ash Ketchup", "Pikachu", "Charizard", "Mickey Mouse", "Bugs Bunny", "Pluto", "Pato Donald", "Pantera Rosa",
            "Jack Sparrow", "Rocky Balboa", "Homer Simpson", "Batman", "Harley Quinn", "Mr. Bean", "Dora la Exploradora", "Peter Griffin", "Spiderman", "Las Supernenas",
            "Papa Pitufo", "Kim Posible", "Yoda", "Bart Simpson", "Mark Evans", "Axel Blaze", "Mordecai y Rigby", "Phineas y Ferb", "Jake el Perro", "Willy Wonka",
            "Jack(Titanic)", "Terminator", "Toretto", "Vito Corleone", "Epi y Blas", "Shrek", "Goku", "Naruto", "Luffy", "Pou",
            "Sonic", "Mario Bros", "Indiana Jones", "Gollum", "Tortugas Ninja", "Frankestein", "Jason Voorhees", "Freddy Krueger", "El Gato con Botas", "Pedro Picapiedra",
            "Scooby-Doo", "Sheldon Cooper", "Barbie", "Princesa Fiona", "Mortadelo", "Filem�n", "Winnie the Pooh", "Pennywise", "Forest Gump", "Peter Pan",
            "James Bond", "Darth Vader", "Hannibal Lecter", "Beetlejuice", "Mortadelo", "Draco Malfoy", "Voldemort", "Godzilla", "King Kong", "Superman" } },
        { "Artistas Internacionales", new List<string> { "Taylor Swift", "Rosal�a", "Drake", "The Weeknd", "Bad Bunny", "Ariana Grande", "Melendi", "Quevedo", "Rihanna", "Bob Dylan",
            "Elvis Presley", "John Lennon", "David Bowie", "Bruce Springsteen", "Freddy Mercury", "Bob Marley", "Michael Jackson", "Madonna", "Jimi Hendrix", "Stevie Wonder",
            "Dr. Dre", "Snoop Dogg", "Kurt Cobain", "Bruno Mars", "Lady Gaga", "Billie Eilish", "Coldplay", "Ed Sheeran", "David Guetta", "Justin Bieber",
            "Eminem", "Dua Lipa", "Post Malone", "Ozzy Osbourne", "Martin Garrix", "Timmy Trumpet", "50Cent", "Daddy Yankee", "Avril Lavigne", "Beyonc�",
            "Britney Spears", "Bon Jovi", "Shakira", "Chayanne", "Christina Aguilera", "Chuck Berry", "Daft Punk", "Enrique Iglesias", "Julio Iglesias", "Eros Ramazzotti",
            "Frank Sinatra", "Jennifer Lopez", "Justin Timberlake", "Kanye West", "El Sevilla", "Laura Pausini", "Mariah Carey", "Miley Cyrus", "Paulina Rubio", "Ricky Martin",
            "Robbie Williams", "Travis Scott", "Maroon 5", "Adele", "Karol G", "Marshmello", "Rauw Alejandro", "XXXTentacion", "Selena G�mez", "Avicii" } },
    };


    private void Start()
    {
        jugadores = GameManager.Instance.totalJugadores;
        impostores = GameManager.Instance.totalImpostores;
        jugadoresText.text = jugadores.ToString();
        impostoresText.text = impostores.ToString();
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

        string temaSeleccionado = temaDropdown.options[temaDropdown.value].text;

        List<string> palabras = temasPalabras[temaSeleccionado];
        string palabraAleatoria = palabras[Random.Range(0, palabras.Count)];

        GameManager.Instance.totalJugadores = jugadores;
        GameManager.Instance.totalImpostores = impostores;
        GameManager.Instance.tema = temaSeleccionado;
        GameManager.Instance.palabra = palabraAleatoria;
        if (jugadores >= 3 && (impostores >= 1 || impostores < jugadores))
        {
            botonSiguiente.SetActive(true);
        }

    }

    public void SeleccionarTemaAleatorio()
    {
        int randomIndex = Random.Range(0, temaDropdown.options.Count);
        temaDropdown.value = randomIndex;
        temaDropdown.RefreshShownValue();
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

    public void MostrarSiguienteJugador()
    {
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
            textoNombre.text = "�Todos han visto su rol!\nAhora pasen el m�vil y comiencen la discusi�n.\nComienza " + GameManager.Instance.jugadores[Random.Range(0, GameManager.Instance.jugadores.Count)].nombre;
            textoRol.text = "�Todos han visto su rol!\nAhora pasen el m�vil y comiencen la discusi�n.\nComienza " + GameManager.Instance.jugadores[0].nombre;
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
        List<string> palabras = temasPalabras[GameManager.Instance.tema];
        string palabraAleatoria = palabras[Random.Range(0, palabras.Count)];
        GameManager.Instance.palabra = palabraAleatoria;
        GameManager.Instance.GenerarJugadores();
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
        textoNombre.text = $"Turno de:\n{jugador.nombre}";
        textoRol.text = jugador.esImpostor
            ? $"ERES IMPOSTOR\n\nTema: {GameManager.Instance.tema}"
            : $"Palabra secreta:\n <b><color=#591884>{GameManager.Instance.palabra} </color></b>\nTema: {GameManager.Instance.tema}";
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
        textoNombre.text = "�Todos han visto su rol!\nAhora pasen el m�vil y comiencen la discusi�n.\nComienza " + GameManager.Instance.jugadores[Random.Range(0, GameManager.Instance.jugadores.Count)].nombre;
        textoRol.text = "�Todos han visto su rol!\nAhora pasen el m�vil y comiencen la discusi�n.\nComienza " + GameManager.Instance.jugadores[Random.Range(0, GameManager.Instance.jugadores.Count)].nombre;
        botonMostrarRol.SetActive(false);
        imageBotonesFinales.SetActive(true);
    }
}
