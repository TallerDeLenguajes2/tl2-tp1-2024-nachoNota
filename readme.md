### �Cu�l de estas relaciones considera que se realiza por composici�n y cu�l por agregaci�n?
Entre las relaciones que existen entre las clases, vemos que los pedidos y el cliente tienen una relacion por composicion,
debido a que cada cliente forma parte de un pedido (si el pedido no existe se borra el cliente); los pedidos y el cadete tienen
una relacion por agregacion, debido a cada pedido puede ser reasignado a otro cadete; los cadetes y la cadeteria tienen una 
relacion de composicion, ya que si se elimina la cadeteria entonces el cadete tambien tendria que eliminarse

### �Qu� m�todos considera que deber�a tener la clase Cadeter�a y la clase Cadete?
S� que no es un m�todo, pero yo le agregar�a a la clase Cadete un atributo llamado recaudadoDia, que lleve un recuento de cuanto lleva recaudado durante el dia con sus pedidos completados
En cuanto a los metodos, Cadete puede tener algunos como para a�adir el pedido a su lista de pedidos, otro para sumarle los $500 recaudados por pedido completado, y otros como para hacer visibles los datos del cadete sin poner los atributos publicos.
En la Cadeteria podriamos poner metodos para asignar un pedido a un cadete (para no crear un objeto Cadete fuera de la clase Cadeteria), otro para saber si hay que pagarle al cadete, etc.

### Teniendo en cuenta los principios de abstracci�n y ocultamiento, que atributos, propiedades y m�todos deber�an ser p�blicos y cu�les privados.
Con estos principios, los atributos deberian ser privados, siendo posible acceder a ellos a traves de metodos publicos

### �C�mo dise�ar�a los constructores de cada una de las clases?
Cada constructor de cada clase se har� dependiendo de sus relaciones por composicion o agregacion. Por ejemplo, la clase cadeteria tendr� en su constructor la lista de cadetes con la que cuenta, por lo que si se elimina la cadeteria, tambien se eliminaran los cadetes. Otro ejemplo es la clase Pedidos, la cual tiene un cliente asociado, por lo que si se elimina el pedido tambi�n lo har� el cliente.