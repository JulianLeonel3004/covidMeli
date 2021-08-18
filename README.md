IMPORTANTE: La conexión con AZURE ya no está disponible, utilice la conexión local
-----------------------------------------------------------------------------------------

------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
Stack:
------------------------------------------------------------------------------------------
IDE - Microsoft Visual Studio Community 2019
Versión 16.10.3

BD - Sql Server

Frontend: Angular 9 

------------------------------------------------------------------------------------------


Para el desarrollo se utilizó C# con NetCore y Entity Framework.
Los UTesting fueron realizados con NUnit y una base de datos en memoria. 

------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------

Ejecución Local.
------------------------------------------------------------------------------------------

1. Descargar código de github desde el branch main.
2. Dirigirse al directorio Scripts y ejecutar cada uno de los scripts en el orden que se muestra.
3. Dirigirse al directorio covid y levantar el proyecto covid.sln.
4. Compilar y correr el proyecto.
5. Dirigirse al archivo environment.ts que se encuentra en CovidFrontApp/src/environments.
6. Comentar la línea API_URL con la conexión remota y descomentar la línea API_URL con el localhost.
7. En el Directorio CovidFrontApp, ejecutar el comando npm install, esperar la descarga y luego ng serve -o para ejecutarlo.

Nota: si ocurre un error de conexión de db, verificar en covid/covid/appsettings.json que la cadena de conexión en "DefaultConnection", esté apuntando a su base de datos local.

------------------------------------------------------------------------------------------
Ejecución Remota con front local.
------------------------------------------------------------------------------------------
Realizar el paso 7 de la ejecución local.

Nota: Si cambio el archivo environment, debe regresarlo a su estado original. Es decir, con API_URL apuntando a la conexión remota.
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
Notas sobre las decisiones del proyecto:
------------------------------------------------------------------------------------------

Paises: Al dejar a libre interpretación la cantidad de paises a la cual se le realiza este test, opté porque se guarde cada país que se ingrese, siempre y cuando no se encuentre en la base de datos previamente.
Ej. Si ingreso "Argentina" para el país de una persona y luego para cualquier otra posterior se vuelve a repetir la nacionalidad, se guardaría la primera vez y no la segunda, utilizando como clave para ambas, el mismo registro.

ADN: En el caso de los adn se usó una lógica similar, se puede guardar uno nuevo, pero no un repetido. A este, se le agregaron las validaciones correspondientes para que no se agreguen caracteres erroneos.

