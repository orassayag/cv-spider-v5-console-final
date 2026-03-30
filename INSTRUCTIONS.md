# Instructions

## Setup Instructions

### Prerequisites

1. **Visual Studio** (2015 or later) or any C# compatible IDE
2. **.NET Framework 4.5.2** or higher
3. **SQL Server** (2012 or later) - Express edition is sufficient
4. **SQL Server Management Studio** (SSMS) - Recommended for database management

### Installation

1. Clone or download the project to your computer:
   ```bash
   git clone https://github.com/orassayag/cv-spider-v5-console-final.git
   cd cv-spider-v5-console-final
   ```

2. Open `CVSpider.sln` in Visual Studio

3. Restore NuGet packages (if prompted)

### Database Setup

1. Create a new database in SQL Server:
   ```sql
   CREATE DATABASE CVBillyRavid2;
   ```

2. Create the required stored procedures in your database:

   ```sql
   -- Create Email table (example structure)
   CREATE TABLE Emails (
       EmailID INT IDENTITY(1,1) PRIMARY KEY,
       Email NVARCHAR(255) UNIQUE NOT NULL,
       CreatedDate DATETIME DEFAULT GETDATE(),
       IsUsed BIT DEFAULT 0
   );

   -- Stored procedure to create a new email
   CREATE PROCEDURE dbo.CreateEmail
       @Email NVARCHAR(255)
   AS
   BEGIN
       INSERT INTO Emails (Email, IsUsed)
       VALUES (@Email, 0);
   END;

   -- Stored procedure to get an email
   CREATE PROCEDURE dbo.GetEmail
       @Email NVARCHAR(255)
   AS
   BEGIN
       SELECT EmailID, Email, CreatedDate, IsUsed
       FROM Emails
       WHERE Email = @Email;
   END;

   -- Stored procedure to get CV mails
   CREATE PROCEDURE dbo.GetCVMails
   AS
   BEGIN
       SELECT EmailID, Email, CreatedDate, IsUsed
       FROM Emails
       WHERE IsUsed = 0;
   END;

   -- Stored procedure to update CV mails
   CREATE PROCEDURE dbo.UpdateCVMails
   AS
   BEGIN
       UPDATE Emails
       SET IsUsed = 1
       WHERE IsUsed = 0;
   END;

   -- Stored procedure to get unused count
   CREATE PROCEDURE dbo.GetUnusedCount
   AS
   BEGIN
       SELECT COUNT(*) AS UnusedCount
       FROM Emails
       WHERE IsUsed = 0;
   END;
   ```

### Configuration

1. Open `App.config` and update the connection string:
   ```xml
   <connectionStrings>
     <add name="MailDB" 
          connectionString="Data Source=YOUR_SERVER;Initial Catalog=CVBillyRavid2;Integrated Security=SSPI" 
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

2. Configure search settings:
   ```xml
   <appSettings>
     <add key="StartIndex" value="0" />
     <add key="EndIndex" value="100000" />
     <add key="LogMailsPath" value="C:\Path\To\Your\Mails.txt" />
   </appSettings>
   ```

   - `StartIndex`: Starting iteration for search loops
   - `EndIndex`: Ending iteration for search loops
   - `LogMailsPath`: Path where exported emails will be saved

### Building the Project

1. In Visual Studio, select **Build > Build Solution** (or press `F6`)
2. Ensure there are no compilation errors
3. The executable will be created in `bin\Debug\` or `bin\Release\`

## Running the Application

### From Visual Studio

1. Press `F5` to run with debugging or `Ctrl+F5` to run without debugging
2. You'll see a console menu with the following options:

```
Select action:
-------------
1 - Search by random words - Multi threads
2 - Search by random words - Single threads
3 - Print mails
```

### From Command Line

```bash
cd bin\Debug
CVSpider.exe
```

## Available Modes

### Mode 1: Search by Random Words - Multi Threads
- Uses parallel execution with up to 6 concurrent threads
- Fastest method for large-scale email collection
- Searches Ask.com with random query terms
- Automatically stores unique emails in the database
- Updates console title with real-time count of unused emails

**Use when:** You need to collect emails quickly and have good network bandwidth

### Mode 2: Search by Random Words - Single Thread
- Uses sequential execution
- Slower but more predictable and easier to debug
- Same search logic as multi-threaded mode
- Better for testing or limited system resources

**Use when:** Testing, debugging, or experiencing threading issues

### Mode 3: Print Mails
- Exports all unused emails from the database to a text file
- Creates a comma-separated list of emails
- Saves to the path specified in `LogMailsPath` configuration
- Marks exported emails as "used" in the database

**Use when:** You need to export collected emails for external use

## How It Works

### Search Process Flow

```
1. Application starts
2. User selects search mode (1 or 2)
3. For each iteration (StartIndex to EndIndex):
   a. Generate random search query
   b. Search Ask.com with pagination (10 pages)
   c. Extract URLs from search results
   d. For each URL:
      - Download page source
      - Extract emails using regex
      - Validate email format
      - Clean/normalize email address
      - Check if email exists in database
      - Insert new email if unique
4. Display found email in console
5. Update title with unused email count
```

### Email Validation

The application performs extensive email validation:
- Regex pattern matching
- Format verification (@ symbol, domain structure)
- Domain correction (common typos like "com.il" → "com")
- Malformed address cleaning
- Duplicate checking against database

### Search Engine

Currently configured to search **Ask.com**. The code includes commented examples for:
- Google
- Bing
- Yahoo
- AOL
- Walla (Israeli search engine)

## Output Files

### Mails.txt
Location: Specified in `LogMailsPath` configuration

Contains comma-separated list of exported emails:
```
example1@domain.com, example2@domain.com, example3@domain.com
```

## Performance Considerations

### Multi-threading Settings
- Default: 6 parallel threads
- Adjustable in `Program.cs`:
  ```csharp
  Parallel.For(0, 10, new ParallelOptions { MaxDegreeOfParallelism = 6 }, count =>
  ```

### Search Range
- Configured via `StartIndex` and `EndIndex` in `App.config`
- Each iteration performs ~10 page searches
- Larger ranges = more emails but longer execution time

## Troubleshooting

### Database Connection Errors
- Verify SQL Server is running
- Check connection string in `App.config`
- Ensure database and stored procedures exist
- Verify user has necessary permissions

### Network Errors
- Check internet connectivity
- Search engines may rate-limit requests
- Consider adding delays between requests if experiencing issues

### No Emails Found
- Search engines may have changed their HTML structure
- URLs might be blocked or filtered
- Consider updating URL extraction patterns in `TextUtils.cs`

### Thread Errors
- Reduce `MaxDegreeOfParallelism` value
- Switch to single-threaded mode (Option 2)
- Check for database connection pool exhaustion

## Legal and Ethical Considerations

**Important:** This tool performs web scraping and automated email collection. Please note:

- Respect website Terms of Service
- Be aware of data protection regulations (GDPR, CAN-SPAM, etc.)
- Implement appropriate rate limiting
- Only collect publicly available information
- Use collected emails responsibly and legally
- Consider ethical implications of automated data collection

## Author

* **Or Assayag** - *Initial work* - [orassayag](https://github.com/orassayag)
* Or Assayag <orassayag@gmail.com>
* GitHub: https://github.com/orassayag
* StackOverflow: https://stackoverflow.com/users/4442606/or-assayag?tab=profile
* LinkedIn: https://linkedin.com/in/orassayag
