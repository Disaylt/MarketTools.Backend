# MarketTools.Backend

## Запуск RU

1. Создайте файл с настройками **вне проекта** с названием "sequreconfig.development.json" или "sequreconfig.Production.json".
2. Конфиг должен содержать описание объекта *SequreSettings* в json. Путь к объекту: *MarketTools.Application.Common.Configuration*.
Пример:
```
  {
  	"Sequre":{
  	  "Proxies":[
  		"23426.3423:t34qaf@rwewa:gserw",
  		"23426.375423:t34qaf@rwewa:gserw"
  	  ],
  	  "TelegramBots":{
  		"Test":"yw54sgaw345aer"
  	  },
  	  "DatabaseConnections":{
  		"Main":"Server=localhost;Database=MpSnakeAspWebApi;Trusted_Connection=True;TrustServerCertificate=True"
  	  },
  	  "Jwt": {
  		  "ValidAudience": "https://localhost:7204",
  		  "ValidIssuer": "https://localhost:7204",
  		  "Secret": "your_secret_key",
  		  "ExpireDay": 30
  		}
  	}
  }
```
3. Команда для запуска контейнера должна содержать
  - Enviroments: MpToolsSettingsPath - Путь к конфигурации проекта в контейнере. **ВАЖНО**: Обязательно в конце пути поставьте '/'. Например MpToolsSettingsPath=/appfiles/.
  - Volume: Из какой папки забрать конфигурацию и в какую поместить(Помещаем в папку указанную в MpToolsSettingsPath).
  - Port: EXPOSE 8080 и 8081.
Пример:
> docker run -v /etc/asp-customer-settings:/appfiles -e MpToolsSettingsPath=/appfiles/ -p 5000:8080 disaylt/markettoolswebapi
