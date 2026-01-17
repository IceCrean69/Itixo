# Meteostanica

Táto .NET konzolová aplikácia každú hodinu stahuje dáta zo zadanej URL vo formáte XML. Následne XML deserializuje, uloží deserializované dáta a serializuje do JSON. Vo formáte JSON zapíše dáta do Databáze, pričom kontroluje stav stanice a zapísaných dát keby náhodou došlo ku chybe.

## Požiadavky a spustenie
- **Nástroje:** .NET 6.0 SDK+, MySQL Server.
- **Príprava:** V MySQL vytvorte databázu `weather_logs` a tabuľku pomocou priloženého SQL skriptu nižšie.
- **Konfigurácia:** V `Program.cs` upravte premennú `conn` (Connection String).
- **Spustenie:** Príkazom `dotnet run` v koreňovom priečinku projektu.

## 📦 Použité knižnice (NuGet balíčky)

Aplikácia využíva nasledujúce závislosti:
- `MySqlConnector` - vysokovýkonný ovládač pre MySQL.
- `Dapper` - Micro-ORM pre rýchle a bezpečné ukladanie dát do SQL.

## SQL Schéma
```sql
CREATE TABLE `weatherlogs` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `downloadedAt` DATETIME NOT NULL,
  `isSuccess` BIT NOT NULL,
  `jsonData` JSON NULL,
  `errorMessage` TEXT NULL
);