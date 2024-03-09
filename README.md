# Studying.273.Testing

Выполнить в PowerShell:
Для запуска тестов в 2 потока:
dotnet test -m:2

Для генерации отчета в папке решения:
allure generate --clean -o Allure-Report

Для открытия сгенерированного отчета:
allure open

Для генерации отчета во временной папке и открытия оного:
allure serve