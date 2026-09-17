1. Введение
Документ описывает перечень артефактов и протоколов проекта ConsoleCalculator.
Область применения: командная разработка, интеграция модулей, сопровождение.
2. Перечень артефактов
Файл / каталог	Назначение	Тип	Этап ЖЦ	В Git
ConsoleCalculator.sln	Файл решения Visual Studio	вспомогательный	проектирование	да
ConsoleCalculator.csproj	Файл проекта C#	вспомогательный	проектирование	да
App.config	Конфигурация .NET Framework	конфигурация	разработка	да
Program.cs	Точка входа приложения	исходный	разработка	да
Infrastructure/ICalculator.cs	Интерфейс всех режимов	исходный	разработка	да
Models/HistoryItem.cs	Модель записи истории	исходный	разработка	да
Services/CalculatorBase.cs	Базовый класс калькулятора	исходный	разработка	да
Services/BasicCalculator.cs	Обычный режим	исходный	разработка	да
Services/EngineeringCalculator.cs	Инженерный режим	исходный	разработка	да
Services/DateCalculator.cs	Режим дат	исходный	разработка	да
Views/MainCalculator.cs	Главное меню	исходный	разработка	да
Properties/AssemblyInfo.cs	Метаданные сборки	вспомогательный	разработка	да
.gitignore	Исключения для Git	конфигурация	разработка	да
README.md	Описание проекта	документация	поставка	да
ARTIFACTS.md	Перечень артефактов (данный ЛР)	документация	поставка	да
docs/diagram.png	Диаграмма компонентов	документация	проектирование	да
bin/	Результаты сборки	производный	поставка	нет
obj/	Промежуточные файлы	производный	разработка	нет
.vs/	Настройки Visual Studio	вспомогательный	разработка	нет
*.user	Пользовательские настройки	вспомогательный	разработка	нет
3. Протоколы взаимодействия
ICalculator
- Участники: Views - Services
- Назначение: единый контракт для режимов.
- Интерфейс: `void Run(); void SetColor();`
- Формат: объекты C#.
History Protocol
- Участники: CalculatorBase - Models.HistoryItem
- Интерфейс: `AddToHistory(string)`, `PrintHistory()`, `ClearHistory()`
- Формат: `List<string>`.
Input Protocol
- Участники: Views - Services
- Интерфейс: `GetNumber(string)`, `GetDate(string)`
- Ограничения: повторный запрос при ошибке.
Exception Protocol
- Участники: Services - System.Exception
- Формат: try-catch с выводом `"Ошибка: {Message}"`.
Color Protocol
- Участники: CalculatorBase → Console
- Интерфейс: `SetColor()`
- Формат: foregroundColor + backgroundColor.
4. Соглашения об именовании и версионировании
Именование
- Классы: `PascalCase` (BasicCalculator)
- Интерфейсы: `I` + PascalCase (ICalculator)
- Методы: `PascalCase`, глагол + существительное (AddToHistory)
- Поля: `camelCase`, защищённые с `_` не используются
- Файлы: совпадают с именем класса
- Пространства имён: `CalculatorProject.<Модуль>`
- Ветки Git: `feature/<название>`, `bugfix/<название>`, `main`
- Коммиты: `<тип>: <краткое описание>` (feat, fix, docs, refactor)
Версионирование (SemVer)
- Формат: `MAJOR.MINOR.PATCH` (например, 1.2.0)
- MAJOR — несовместимые изменения
- MINOR — новая функциональность
- PATCH — исправления
- Теги: `v1.0.0`, `v1.1.0`
5. Заключение
Документ фиксирует все артефакты и правила взаимодействия в проекте.
Он упрощает командную разработку, тестирование и дальнейшую интеграцию модулей.
