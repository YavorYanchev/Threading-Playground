# Threading-Playground
Learning concurrent processing

Everything is from msdn tutorials about threads.

Language: C#
I will use combination of my native language and English for notes :D
(Many typos are expected :D)

Когато се стартира процес, CLR-a автоматично създава 1 foreground thread за изпълнение на кода.
Заедно с този main foreground thread, процес може да създава 1 или няколко thread-a за изпълнение на
части от програмния код свързан с процеса.
Тези thread-ове могат да се изпълняват в:
* foreground
* background
Можем да използваме ThreadPool класа за да изпълняваме код на worker threads, които се управляват от CLR-a.


### Стартиране на thread
Стартираме thread като предоставяме делегат, който представлява метод който thread-a ще изпълни.
След това извикваме Start за започване на изпълнението.

### Получаване на Thread обекти
Можем да използваме статичното CurrentThread property за получаване на референция за текущия(изпълняващ) thread от кода,който thread-a изпълнява.

### Foreground и Background threads
Инстанциите на Thread класа представляват или foreground threads или background threads.

Background threads са идентични на foreground threads с 1 изключение:
Background thread не държи процеса работещ ако всички foreground threads са прекратени.
След като всички foreground threads са били спряни, runtime-а спира всички background thread=ове и спира.

По default, следните thread-ове се изпълняват в foreground:
* the main application thread
* всички thread-ове създадени чрез извикване на Thread class constructor

Следните thread-ове се изпълняват в background по default:
* Thread pool threads, които са pool от worker threads поддържани от runtime-a. Можем да конфигурираме thread pool-a и да планираме работа на thread pool threads чрез ThreadPool класа.

* Всички threads,които влизат managed execution среда от unmanaged код.


**Пояснение**
Task-based asynchronous операции автоматично изпълняват на thread pool threads.
Task-based asynchronous операции използват Task и Task<TResult> класове за имплементиране на
task-based asynchronous pattern.


Можем да сменим thread да се изпълнява в background като променим IsBackground property-то по всяко време.

Background threads са полезни за операции, които трябва да продължат докато приложението работи но не трябва да пречат на приложението да спре, като например monitoring file system changes или incoming socket connections.
