To run this application first Delete all files in the migratios folder and then run:

'Add-Migration InitialCreate' command in the 'Package Manager Console' 

and then the 'Update-Database' command

make shure that the conn string is pointing out to your database

¿Qué opina de pasar el id de usuario como input del endpoint? 
No es bueno exponer informacion importante en las urls, si hacemos llamadas post es mejor enviarlas en un cuerpo.
en GET seria usar otra informacion importante como el DNI, Nro cuenta o el Nombre Y apellido

¿Cómo mejoraría la transacción para asegurarnos de que el usuario que pidió la compra es quien dice ser?
desde la UI pedir infomacion como el pass para acceder a la cuenta, nro de tarjeta, algun captcha.
en la api verificar que la informacion de usuario y la cuentan existen, que posee suficiente dinero para efectuar la compra.
