# Angular-MVC4
Prácticas de Angular utilizando ASP MVC 4 como backend

## Repaso .net

### UnitOfWork Clasico

Implementación del patron Unit of Work y Repository. 

Unit of Work: Según Martin Fowler mantiene registra operaciones de persistencia y coordina la persistencia de los mismos y la resolución de problemas de concurrencia.
Repository: Mediador entre el dominio y las capas de mapeo de datos, utiliza una interfaz similar a la que provee una colección para acceder a objetos de dominio. 

Un servicio obtiene un Unit of work y un repositorio al momento de ser creado, al repositorio le solicita registrar operaciones de persistencia y eventualmente al unit of work le solicita efectuar las operaciones registradas por los repositorios.
En realidad cuando a un repositorio se le solicita registrar una operación, lo que hace el repositorio es solicitarle al unit of work que persista la operación enviándose a sí mismo y a la entidad a persistir. 

La implementación del unit of work es incompleta pero sirve para mostrar la interacción entre el servicio, el repositorio y el unit of work.

### UnitOfWork EF Clasico

Aplicación del patrón Unit of work usando Entity Framework como ORM en un bosquejo incompleto de lo que sería una aplicación de n-capas. Básicamente permite que haya un DataContext por hilo creado o solicitud http entrante.

Basicamente en este ejemplo se puede observar que solo los unit of work pueden persistir cambios en el origen de datos y los repositorios solo se comunican con el unit of work para que registre operaciones de persistencia, aunque a diferencia el ejemplo anterior paradójicamente el unit of work en estos casos lo que hace es devolverle la solicitud al repositorio porque son los repositorios los que saben cómo registrar las operaciones de persistencia. 
El resto de los detalles es muy similar al primer ejemplo: El servicio que coordina que se ejecute la funcionalidad solicitada por un cliente utiliza a los repositorios para que registren operaciones de persistencia y eventualmente le pide al unit of work que aplique las operaciones registradas en el origen de datos. 

Los cambios que hay con respecto al primer ejemplo son fundamentales: 
- El Unit of work es el único que sabe cómo se persisten cambios en la base de datos, los repositorios no pueden hacerlo. 
- Los repositorios saben cómo registrar las operaciones de persistencia pero le solicitan al unit of work que les pida de regreso que los registre. 

El mundo del revés, el unit of work no registra las operaciones y el repositorio si, el repositorio no sabe efectuar cambios en el origen de datos pero el unit of work si. 

Componentes: 

Se tiene una clase servicio que coordina la ejecución de todas las funcionalidades de las que es responsable un módulo del sistema, la misma es instanciada por cada solicitud de usuario y cuando es creada se le suministra el unit of work y los repositorios que requiere para coordinar operaciones de persistencia. 

La clase servicio puede instanciar entidades de negocio por si misma, acceder a sus propiedades y coordinar las operaciones de persistencia, aunque la lógica de negocio se encuentra en las propias entidades de negocio. 

La clase servicio puede obtener de los repositorios entidades de negocio persistidas, para ello los repositorios necesitan acceder al ObjectContext que corresponda y retornar los objetos de entidades de negocio consultadas, no entiendo como funciona el mapeo implicito de las clases que genera el EntityModel de EF con las entidades de negocio pero ambas tienen que respetar los nombres y tipos de sus propiedades.

La clase servicio solicita a los repositorios registrar operaciones de persistencia y eventualmente al unit of work realizar las operaciones de persistencia que han sido registradas por los repositorios. 

La clase unit of work solo hace dos cosas:
1. Almacenar operaciones de persistencia: El repositorio se envia a si mismo para que el unit of work le ordene de regreso almacenar la operación de persistencia que el repositorio le pidió
2. Efectuar todas las operaciones de persistencia que fueron almacenadas por los repositorios en el origen de datos

Capas:

La capa de infraestructura posee definiciones de interfaces para las clases concretas Unit of work y los repositorios que usa el Unit of work para persistir cambios, se define el supertipo AggregateRoot

La capa de repositorios incluye:
- DataContext de la biblioteca: Esta clase es la puerta de acceso al manejo de persistencia y recuperación de AggregateRoot (Clases del modelo de negocio, no entidades del Entity Framework), inicializa todas las colecciones AggregateRoot que el módulo de la biblioteca necesita para sus funcionalidades que requieren interactuar con el origen de datos. 
- Contenedores del DataContext: Vienen en dos variantes, la que usa HttpDataContext y la que usa hilos. 
- Clase generica de repositorios: Tipo de la clase generica es AggregateRoot e implementa la interfaz para repositorios que utilizan los unit of work que ha sido definida en la capa de infraestructura, los métodos que implementa de dicha interfaz son aquellos que sirven para persistir la creacion, modificacion o eliminacion de registros. Entre el resto de los métodos que provee la clase genérica se encuentran los métodos que sirven para registrar operaciones de persistencia en el Unit of work que le fue suministrado al repositorio en su instanciación, el resto de los métodos que el repositorio provee sirven para consultar registros por id o para obtener todos que también son comunes a todos los repositorios.
- Repositorios concretos: Uno por Aggregate Root, son subclases de la clase generica de repositorios y cada uno implementa la interfaz que le corresponde al repositorio concreto del aggregate root en cuestión, dicha interfaz define métodos que son exclusivos para dicho repositorio y están definidas en la capa de modelo porque los métodos de consulta concretos están relacionados a la lógica de negocio, en dichos métodos los repositorios concretos accederán al ObjectContext y devolverán los objetos correspondientes de una forma similar a como lo hace la clase repositorio genérica para las consultas comunes a todos los repositorios concretos que heredan de la misma. 
- Unit of work: Implementa la interfaz de unit of work definida en la capa de infraestructura, por lo tanto implementa los métodos que sirven para almacenar operaciones de persistencia y el método utilizado para aplicar las operaciones de persistencia contenidas, para realizar esto ultimo un objeto unit of work necesita acceder al ObjectContext. En todo el sistema se accede al ObjectContext de dos formas: Consultas de los repositorios y el commit del Unit of Work únicamente. 

La capa model contiene:
- Entidades y Aggregate roots: Solo contiene lógica de negocio.
- Interfaces de repositorios concretos: Interfaces que posee definiciones únicas para el repositorio concreto correspondiente al AggregateRoot. 

La capa de servicio contiene: 
- BibliotecaService: Agrupa todas las funcionalidades que puede solicitar un cliente dentro del modulo de biblioteca. Al momento de ser creado se le asigna una instancia unit of work y los repositorios que el servicio requiere para interactuar con el origen de datos.
