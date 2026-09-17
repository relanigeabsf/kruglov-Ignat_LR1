1. Введение
Документ описывает перечень артефактов и протоколов проекта ConsoleCalculator.
Область применения: командная разработка, интеграция модулей, сопровождение.
2. Перечень артефактов
Имя	Тип	Категория	Назначение	В Git	Расположение
ConsoleCalculator.sln	вспомогательный	проектный	файл решения Visual Studio	да	корень
ConsoleCalculator.csproj	вспомогательный	проектный	файл проекта C#	да	корень
Program.cs	исходный	код	точка входа приложения	да	корень
ICalculator.cs	исходный	код	интерфейс всех режимов калькулятора	да	Infrastructure/
HistoryItem.cs	исходный	код	модель записи истории	да	Models/
CalculatorBase.cs	исходный	код	базовый класс с общей логикой	да	Services/
BasicCalculator.cs	исходный	код	обычный режим	да	Services/
EngineeringCalculator.cs	исходный	код	инженерный режим	да	Services/
DateCalculator.cs	исходный	код	режим работы с датами	да	Services/
MainCalculator.cs	исходный	код	главное меню	да	Views/
AssemblyInfo.cs	вспомогательный	проектный	метаданные сборки	да	Properties/
App.config	конфигурация	конфиг	настройки .NET Framework	да	корень
.gitignore	конфигурация	конфиг	список исключений для Git	да	корень
README.md	документация	проектный	описание проекта	да	корень
ARTIFACTS.md	документация	проектный	этот документ	да	корень
diagram.png	документация	проектный	диаграмма компонентов	да	docs/
bin/	производный	сборка	результаты компиляции	нет	корень
obj/	производный	сборка	промежуточные файлы	нет	корень
.vs/	вспомогательный	IDE	локальные настройки Visual Studio	нет	корень
*.user	вспомогательный	IDE	пользовательские настройки	нет	корень
log.txt	производный	логи	файл логов	нет	корень
3. Протоколы взаимодействия
ICalculator
- Участники: Views → Services
- Назначение: единый контракт для режимов.
- Интерфейс: `void Run(); void SetColor();`
- Формат: объекты C#.
History Protocol
- Участники: CalculatorBase → Models.HistoryItem
- Интерфейс: `AddToHistory(string)`, `PrintHistory()`, `ClearHistory()`
- Формат: `List<string>`.
Input Protocol
- Участники: Views → Services
- Интерфейс: `GetNumber(string)`, `GetDate(string)`
- Ограничения: повторный запрос при ошибке.
Exception Protocol
- Участники: Services → System.Exception
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

## 5. Заключение

Документ фиксирует все артефакты и правила взаимодействия в проекте.
Он упрощает командную разработку, тестирование и дальнейшую интеграцию модулей.
