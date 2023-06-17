# Hamer.Thomas.SegundoParcial
Título: La Generala.
Sobre mí: Hola, soy Thomas Hamer, me gusta la programación y la verdad me gustó mucho hacer este trabajo, a comparación del parcial anterior, que no me había gustado.

Resumen: La aplicación es el juego la Generala y se juega tirando 5 dados, formando distintas combinaciones, que algunas especiales suman más puntos.

![DiagramaDeClases](https://i.gyazo.com/7025c2538e85309b769900b1f03421f2.png)
SQL: utilicé SQL para la base de datos del juego, allí se guardaban, los usuarios, las salas y las estadísticas, en algunos casos, tuve que hacer un SELECT de dos tablas al mismo tiempo, igualando su ID.

Manejo de excepciones: En los métodos para utilizar SQL usé un manejo de excepciones, ya que al implementar SQL, al más mínimo error, puede lanzar una excepción.

Unit testing: Lo utilicé para probar 4 Metodos.

Generics: Lo usé para pasar un parámetro sin especificar el tipo.

Serialización: Hice un archivo JSON,XML y TXT serializando las estadísticas,salas y usuarios.

Escritura de archivos: Hice un archivo pasandole las estadísticas.

Interfaces: Lo utilicé para agregar los métodos de la base de datos.

Delegados: Lo utilicé para el sort, ya que es un uso común, para especificar cuál es el tipo de sort que se quiere ejecutar.

Task y Eventos: Implementé los dos al mismo tiempo, ya que para hacer el Cronómetro en las partidas, necesitaba hacer una tarea para que mientras el cronómetro esté funcionando, la partida pueda seguir jugándose, haciendo así una programación multi-hilo.