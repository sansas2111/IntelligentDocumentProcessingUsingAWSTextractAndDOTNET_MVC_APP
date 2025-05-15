# AWS Textract Document Processing Web Application

This .NET Core MVC web application demonstrates intelligent document processing using AWS Textract. It allows users to upload documents (images or PDFs) and extract text content using AWS's powerful OCR capabilities.

## Features

- Document upload interface for PDFs and images
- Text extraction using AWS Textract
- Responsive Bootstrap UI
- Error handling and validation
- Real-time text extraction results display

## Prerequisites

- .NET 8.0 SDK or later
- AWS Account with Textract access
- AWS Credentials configured locally

## Getting Started

1. Clone the repository:
```powershell
git clone [repository-url]
cd TextractWebApp
```

2. Configure AWS Credentials:
   - Using AWS CLI:
     ```powershell
     aws configure
     ```
   - Or manually create `%UserProfile%\.aws\credentials`:
     ```ini
     [default]
     aws_access_key_id = YOUR_ACCESS_KEY
     aws_secret_access_key = YOUR_SECRET_KEY
     ```

3. Update AWS Region in `appsettings.json` if needed:
```json
{
  "AWS": {
    "Region": "your-preferred-region"
  }
}
```

4. Run the application:
```powershell
dotnet run
```

5. Access the application at `https://localhost:5001` or `http://localhost:5000`

## Project Structure

- `Controllers/`
  - `HomeController.cs` - Main controller handling file uploads and Textract integration
- `Models/`
  - `DocumentViewModel.cs` - View model for document upload and text extraction
- `Views/`
  - `Home/Index.cshtml` - Upload interface
  - `Home/Result.cshtml` - Text extraction results display
- `wwwroot/` - Static files (CSS, JavaScript, etc.)

## AWS Textract Integration

The application uses AWS Textract's `DetectDocumentTextAsync` API to extract text from uploaded documents. The integration is configured in `Program.cs` using the AWS .NET SDK:

```csharp
builder.Services.AddAWSService<IAmazonTextract>();
```

## Error Handling

The application includes:
- Input validation for file uploads
- Exception handling for AWS service calls
- User-friendly error messages
- Logging of processing errors

## Security Considerations

- Configure proper AWS IAM roles and permissions
- Implement file type validation
- Add appropriate file size limits
- Consider implementing user authentication
- Use HTTPS in production

## Production Deployment

For production deployment:
1. Configure proper AWS credentials management
2. Set up proper logging
3. Configure CORS if needed
4. Implement rate limiting
5. Add monitoring and alerts
6. Consider using AWS S3 for large file handling

## Contributing


1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- AWS Textract Documentation
- ASP.NET Core Documentation
- Bootstrap Documentation
