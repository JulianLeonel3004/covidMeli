------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
Stack:
IDE - Microsoft Visual Studio Community 2019
Versión 16.10.3

BD - Sql Server

Frontend: Angular 9 (en proceso)
------------------------------------------------------------------------------------------


Para el desarrollo se utilizó C# con NetCore y Entity Framework.
Los UTesting fueron realizados con NUnit y una base de datos en memoria. 

------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------

Ejecución Local.

1. Descargar código de github desde el branch main.
2. Dirigirse al directorio Script y ejecutar cada uno de los scripts en el orden que se muestra.
4. Dirigirse al directorio covid y levantar el proyecto covid.sln.
5. Compilar y correr el proyecto.

Nota: si ocurre un error de conexión de db, verificar en covid/covid/appsettings.json que la cadena de conexión en "DefaultConnection", esté apuntando a su base de datos local.

------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
Notas sobre las decisiones del proyecto:

Paises: Al dejar a libre interpretación la cantidad de paises a la cual se le realiza este test, opté porque se guarde cada país que se ingrese, siempre y cuando no se encuentre en la base de datos previamente.
Ej. Si ingreso "Argentina" para el país de una persona y luego para cualquier otra posterior se vuelve a repetir la nacionalidad, se guardaría la primera vez y no la segunda, utilizando como clave para ambas, el mismo registro.

ADN: En el caso de los adn se usó una lógica similar, se puede guardar uno nuevo, pero no un repetido. A este, se le agregaron las validaciones correspondientes para que no se agreguen caracteres erroneos.

