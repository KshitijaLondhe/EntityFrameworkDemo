namespace EntityFrameworkDemo.Models
{
    public class BookCrud
    {
        private readonly ApplicationDbContext db;
        public BookCrud(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Book> GetBooks()
        {
            //LINQ
            //var result = from b in db.Books
            //             select b;

            //return result;

            // Lambda
            return db.Books.ToList();
        }
        public Book GetBookById(int id)
        {
            //LINQ
            //var result= (from b in db.Books
            //            where b.id==id
            //            select b).SingleOrDefault();
            //return result;

            // Lambda

            return db.Books.Where(x => x.id == id).SingleOrDefault();


        }
        public int AddBook(Book bk)
        {
            int result = 0;
            // add data in the DbSet 
            db.Books.Add(bk);
            // Add() will add emp object in the DbSet
            // update changes to Db
            result = db.SaveChanges();
            return result;
        }
        public int UpdateBook(Book bk)
        {
            int result = 0;
            // search the data that we need to modify in the DbSet
            var e = db.Books.Where(x => x.id == bk.id).SingleOrDefault();
            if (e != null)
            {
                //update new changes
                bk.name = bk.name;
                bk.author = bk.author;
                bk.price = bk.price;
                // update the changes to DB
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteBook(int id)
        {
            int result = 0;
            // search the data that we need to modify in the DbSet
            var b = db.Books.Where(x => x.id == id).SingleOrDefault();
            if (b != null)
            {
                //remove from DbSet
                db.Books.Remove(b);
                // update the changes to DB
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
