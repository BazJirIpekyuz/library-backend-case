using LibraryManagement.Library.Entities;

namespace LibraryManagement.Library.TextParsers
{
    /// <summary>
    /// Book input text parser.
    /// </summary>
    public class BookInputTextParser : IInputTextParser<Book>
    {
        /// <summary>
        /// Parse book input text and create a list of book instance.
        /// </summary>
        /// <param name="input">book data.</param>
        /// <returns></returns>
        public List<Book> Parse(string input)
        {
            List<Book> books = new List<Book>();

            string[] booksInputData = input.Split("Book:", StringSplitOptions.RemoveEmptyEntries);

            foreach (string bookInputData in booksInputData)
            {
                books.Add(ParseBookData(bookInputData));
            }

            return books;
        }

        /// <summary>
        /// Parse book data ande create a book instance from it.
        /// </summary>
        /// <param name="bookInputData">book input data.</param>
        /// <returns>a book instance.</returns>
        private Book ParseBookData(string bookInputData)
        {
            Book book = new Book();
            string[] bookPropertyNameAndValueInputArr = bookInputData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var bookPropertyNameAndValueInput in bookPropertyNameAndValueInputArr)
            {
                try
                {
                    string[] bookPropertyNameAndValue = bookPropertyNameAndValueInput.Split(":");
                    string bookPropertyName = bookPropertyNameAndValue[0];
                    string bookPropertyValue = bookPropertyNameAndValue[1].Trim();

                    switch (bookPropertyName)
                    {
                        case "Author":
                            book.Authors.Add(bookPropertyValue);
                            break;

                        case "Title":
                            book.Title = bookPropertyValue;
                            break;

                        case "Publisher":
                            book.Publisher = bookPropertyValue;
                            break;

                        case "Published":
                            book.PublicationYear = int.Parse(bookPropertyValue);
                            break;

                        case "NumberOfPages":
                            book.NumberOfPages = int.Parse(bookPropertyValue);
                            break;
                        case "ISBN":
                            book.ISBN = bookPropertyValue;
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    // TODOs: logging and handling exceptions.
                    throw;
                }
            }

            return book;
        }
    }
}
