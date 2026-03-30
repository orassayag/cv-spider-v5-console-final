# Contributing

Contributions to this project are [released](https://help.github.com/articles/github-terms-of-service/#6-contributions-under-repository-license) to the public under the [project's open source license](LICENSE).

Everyone is welcome to contribute to this project. Contributing doesn't just mean submitting pull requests—there are many different ways for you to get involved, including answering questions, reporting issues, improving documentation, or suggesting new features.

## How to Contribute

### Reporting Issues

If you find a bug or have a feature request:
1. Check if the issue already exists in the [GitHub Issues](https://github.com/orassayag/cv-spider-v5-console-final/issues)
2. If not, create a new issue with:
   - Clear title and description
   - Steps to reproduce (for bugs)
   - Expected vs actual behavior
   - Error messages (if applicable)
   - Your environment details (OS, .NET version, SQL Server version)

### Submitting Pull Requests

1. Fork the repository
2. Create a new branch for your feature/fix:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. Make your changes following the code style guidelines below
4. Test your changes thoroughly
5. Commit with clear, descriptive messages
6. Push to your fork and submit a pull request

### Code Style Guidelines

This project uses:
- **C# 6.0** (.NET Framework 4.5.2)
- **Visual Studio** IDE conventions
- **SQL Server** stored procedures for data access

Before submitting:
```bash
# Build the solution to ensure no compilation errors
msbuild CVSpider.sln /p:Configuration=Release

# Test the application with different search modes
# Run from command line or Visual Studio
```

### Coding Standards

1. **Separation of Concerns**: Keep BLL (Business Logic Layer) and DAL (Data Access Layer) separate
2. **Error handling**: Use try-catch blocks appropriately, especially for network operations
3. **Database access**: Always use stored procedures, never inline SQL
4. **Connection management**: Always dispose of database connections using `using` statements
5. **Thread safety**: Be mindful of shared resources when using parallel execution
6. **Naming**: Use clear, descriptive names following C# conventions (PascalCase for classes/methods, camelCase for parameters)

### Adding New Features

When adding new features:
1. Update the appropriate layer:
   - `BLL.cs` for business logic
   - `DAL.cs` for database operations
   - `Actions.cs` for search/processing logic
   - `TextUtils.cs` for utility functions
2. Add corresponding SQL stored procedures if needed
3. Update `App.config` for new configuration settings
4. Test with both single-threaded and multi-threaded modes
5. Document new configuration parameters

### Database Changes

When modifying database schema or stored procedures:
1. Provide SQL migration scripts
2. Update the `DbUtilsDal.cs` if needed
3. Document the changes in your pull request
4. Ensure backward compatibility when possible

### Search Engine Updates

If adding or modifying search engine queries:
1. Test thoroughly to avoid rate limiting
2. Update URL patterns in `Actions.cs`
3. Verify email extraction still works correctly
4. Consider respectful scraping practices (delays, user agents)

## Questions or Need Help?

Please feel free to contact me with any question, comment, pull-request, issue, or any other thing you have in mind.

* Or Assayag <orassayag@gmail.com>
* GitHub: https://github.com/orassayag
* StackOverflow: https://stackoverflow.com/users/4442606/or-assayag?tab=profile
* LinkedIn: https://linkedin.com/in/orassayag

Thank you for contributing! 🙏
