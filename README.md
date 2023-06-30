# Hamer.Thomas.SegundoParcial
Título: La Generala.
Sobre mí: Hola, soy Thomas Hamer, me gusta la programación y la verdad me gustó mucho hacer este trabajo, a comparación del parcial anterior, que no me había gustado.

Resumen: La aplicación es el juego la Generala y se juega tirando 5 dados, formando distintas combinaciones, que algunas especiales suman más puntos.

![DiagramaDeClases](https://i.gyazo.com/7e9fd8d76acdf24ce41e7d8f5e113ac6.png)
# SQL: utilicé SQL para la base de datos del juego, allí se guardaban, los usuarios, las salas y las estadísticas, en algunos casos, tuve que hacer un SELECT de dos tablas al mismo tiempo, igualando su ID.
![SQL](https://i.gyazo.com/7f1f6e0f8786d54c75aeadca0b0dde94.png)
![SQL](https://i.gyazo.com/c3baad6239651ff90b16a21eb931dacf.png)
# Manejo de Excepciones: En los métodos para utilizar SQL usé un manejo de excepciones, ya que al implementar SQL, al más mínimo error, puede lanzar una excepción.
![Manejo de Excepciones](https://i.gyazo.com/ff5b0403f2ca4960f8061476fa075d7a.png)
![Manejo de Excepciones](https://i.gyazo.com/9611c741c0d90f96ed99db74320ce2a2.png)
# Unit Testing: Lo utilicé para probar 10 Metodos.
![Unit Testing](https://i.gyazo.com/4acb4c6e8f2191b9fd63f3d8ef8419b7.png)
# Generics: Lo usé para pasar un parámetro sin especificar el tipo.
![Generics](https://i.gyazo.com/bb0ced265d2f8281efeae1c4fb10f253.png)
# Serialización: Hice un archivo JSON,XML y TXT serializando las estadísticas,salas y usuarios.
![Serialización](https://i.gyazo.com/fe7a88b79f09d55e676d2c2c5e81fe88.png)
# Escritura de Archivos: Hice un archivo pasandole las estadísticas, salas y usuarios, los mismos se encuentran en Hamer.Thomas.SegundoParcial\bin\Debug.
![Escritura de Archivos](https://i.gyazo.com/a58220609e8d44b88ed86efe938aa41d.png)
![Escritura de Archivos](https://i.gyazo.com/6fb307381c3bf1ca7032e4261059a800.png)
![Escritura de Archivos](https://i.gyazo.com/b015d49dcc3ecf05953dc66bb4fbe858.png)
# Interfaces: Lo utilicé para agregar los métodos de la base de datos.
![Interfaces](https://i.gyazo.com/d7e7909d6f4fa2f85d3623bbb689fa38.png)
# Delegados: Lo utilicé para el sort, ya que es un uso común, para especificar cuál es el tipo de sort que se quiere ejecutar.
![Delegados](https://i.gyazo.com/7ac4fa2ca308b78e076e10cd335611f8.png)
![Delegados](https://i.gyazo.com/b3011e8cb640c80504242d1e52ca4948.png)
![Delegados](https://i.gyazo.com/6c40548d24d8c895c4a1fc20980e1e74.png)
![Delegados](https://i.gyazo.com/90b815a7d4d44f24d35ec5fbb2843c7c.png)
# Task y Eventos: Implementé los dos al mismo tiempo, ya que para hacer el Cronómetro en las partidas, necesitaba hacer una tarea para que mientras el cronómetro esté funcionando, la partida pueda seguir jugándose, haciendo así una programación multi-hilo.
![Task y Eventos](https://i.gyazo.com/567d554f9bc6cdf709efc49614fa4d7e.png)
![Task y Eventos](https://i.gyazo.com/8d43ae39bac9c7d36b7d48810162e357.png)
![Task y Eventos](https://i.gyazo.com/b792cf439504d785fcf2a0bbe6c327ed.png)
![Task y Eventos](https://i.gyazo.com/9f525543849582f8a51d04dbdf0744f8.png)

# Manual De Usuario
Aqui explicare el como usar dicha Aplicación.
1.En Caso que el Usuario no este Conectado a la Base de Datos SQL le saldra este Mensaje de Advertencia.
![Advertencia](https://i.gyazo.com/6bf722530a996a2be80815a1f448223c.png)
Usted no podra Iniciar la Aplicación hasta que no este Conectado a la Base de Datos, Generala_Segundo_Parcial con el archivo .bak
2.Para poder Loguearse debera Ingresar algunos de estos Usuarios.
![Logueo](https://i.gyazo.com/d181237c8d5cd2b7d70108e7561ddc7b.png)
En caso de que el Usuario sea Correcto pero la Clave no le saldra una Advertencia.
![Logueo](https://i.gyazo.com/44a34cb9040d6e16f089a72f44381153.png)
Y si el Usuario y la Clave no sea el Correcto o no esten Registrados saldra otra Advertencia.
![Logueo](https://i.gyazo.com/20452503ef2cde03c1447f42117fce2b.png)
Si Ustede Desea Registrar un Nuevo Usuario podra hacerlo y se le Preguntara si esta Seguro de Hacerlo.
![Logueo](https://i.gyazo.com/0238f8e420dcd686942664b6b7df3f41.png)
3.En La Sala podra ver las Partidas que Finalizaron o que Estan en Juego, tambiem podra Ordenarlas, Crear una Nueva Sala o ver sus Estadisticas.
![Sala](https://i.gyazo.com/88d71c2e5275f9ba7d56b34eac790f2b.png)
![Sala](https://i.gyazo.com/1e2e1407e7b971fa8759239f1305a5ad.png)
![Sala](https://i.gyazo.com/b0926a6a57350e1fbba178ec7fd1de04.png)
4.En Caso que desee crear una Nueva Sala le saldra este Mensaje
![Sala](https://i.gyazo.com/64bf5b73d29e1847981c338c2ababff2.png)
Le Recomiendo que Despues de Crear la Sala utilize el Boton de Actializar Salas, para que la Nueva Sala se Cargue y Usted pueda verla y Entre a Jugar.
![Sala](https://i.gyazo.com/f44b3dbe2d6bb1da3a81902b17f5a52c.png)
Usted podra entrar a cualquier Partida que vea en el Listado de Salas pero Recuerde que si al Partida est Finalizada no podra Tirar los Dados o alguna otra Accion.
![Sala](https://i.gyazo.com/4f05e988c19ff054b01ee86377202aa0.png)
5.Usted Tendra 3 Oportunidades para Tirar y podra Seleccionar los Dados que desee quedarse.
![Juego](https://i.gyazo.com/e7645888cc38cb5d4b58f50e5fe13a85.png)
Una vez hecho debera Confirmar su Eleccion y tachar en caso de que le haya tocado Generala,Libre o Poker.
Usted podra irser de la Partida si desea pero recuerde que si Toca el boton Salir, Usted Sale pero no Guarda la Partida.
Le Recomendamos que Siempre toque el Boton Guardar y Salir y que una vez que lo haga siempre Actualize las Salas.