# Pokedex-Project
Pokedex App by lduenas

* ¿Que tipo de aplicación proponen construir a partir del conjunto de datos seleccionado?
    
Se realizara una aplicacion movil multiplataforma para consultar los pokemon disponibles en el pokedex.

* ¿A que mercado o sector va dirigido?

A los fanaticos y nostalgicos de los videojuegos, o que requieren obtener informacion de los distintos pokemon

* ¿Que pasos tienes que realizar o cubrir para poder consumir información a partir del conjunto de datos seleccionado?
    Al realizar la aplicacion en C#, hacemos uso del paquete HttpClient para obtener el dataset y manipularlo

```c#

    var uri = new Uri("https://api.myjson.com/bins/1c5nwx");
            Rootobject root;
            string results = string.Empty;
            ObservableCollection<Item> items = new ObservableCollection<Item>();
            HttpClient wc = new HttpClient();
            HttpResponseMessage response = await wc.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic jo = JObject.Parse(responseBody);
            root = jo.ToObject<Rootobject>();

```
   - - -
   
   **Imagenes**
   
   ![SplashScreen](https://github.com/luisduenas/Pokedex-Project/blob/master/img/SplashScreen.png)

   ![Principal](https://github.com/luisduenas/Pokedex-Project/blob/master/img/Start.png)

   ![Filtros](https://github.com/luisduenas/Pokedex-Project/blob/master/img/filter.png)

   ![Detalles](https://github.com/luisduenas/Pokedex-Project/blob/master/img/specs.png)

   ![Acerca de](https://github.com/luisduenas/Pokedex-Project/blob/master/img/info.png)




