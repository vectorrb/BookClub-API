using BookClubAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookClubAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		public Db01Context context { get; }
		public BookController(Db01Context appDBContext)
		{
			context = appDBContext;
		}

		[HttpGet]
		[Route("")]
		public ActionResult GetAllBooks()
		{
			List<Rbbook> bookList = context.Rbbooks.ToList();
			return Ok(bookList);
		}

		[HttpGet]
		[Route("{id}")]
		public ActionResult GetBookById(int id)
		{
			Rbbook book = context.Rbbooks.FirstOrDefault(x => x.BookId == id);
			return Ok(book);
		}

		[HttpGet]
		[Route("comments/{id}")]
		public ActionResult GetComments(int id)
		{
			List<Rbcomment> comments = context.Rbcomments
				.Where(c => c.BookId == id)
				.ToList();

			return Ok(comments);
		}

		[HttpPost]
		[Route("postcomment")]
		public ActionResult PostComment(Rbcomment rbcomment)
		{
			context.Rbcomments.Add(rbcomment);
			context.SaveChanges();
			return Ok();
		}

		[HttpGet]
		[Route("seeYourLikedBooks/{userId}")]
		public ActionResult getYourLikedBooksList(int userId)
		{
			var likedBooksList = context.RbusersLikesDislikes
				.Where(c => c.UserId == userId && c.LikeDislike == true)
				.ToList();
			if (likedBooksList == null)
			{
				return BadRequest();
			}
			return Ok(likedBooksList);
		}

		[HttpGet]
		[Route("genre/{genreName}")]
		public ActionResult getBooksByGenre(string genreName)
		{
			List<Rbbook> booksByGenre = context.Rbbooks
				.Where(b => b.Genre == genreName)
				.ToList();
			return Ok(booksByGenre);	
		}

		[HttpPost]
		[Route("addbook")]
		public ActionResult AddBook(Rbbook newBook)
		{
			context.Rbbooks.Add(newBook);
			context.SaveChanges();
			return Ok();
		}

		[HttpPost]
		[Route("removeFromUsersLiked/{userId}")]
		public ActionResult Remove(int userId, int bookId)
		{
			RbusersLikesDislike fetchRecord = context.RbusersLikesDislikes
				.Where((b) => b.UserId == userId && b.BookId == bookId)
				.FirstOrDefault();
			context.Remove(fetchRecord);
			return Ok();
		}

		[HttpPut]
		[Route("edit/{bookId}")]
		public ActionResult Edit(int bookId, Rbbook rbbook)
		{
			Rbbook fetchBook = context.Rbbooks.FirstOrDefault(b => b.BookId == bookId);
			if (fetchBook == null)
				return BadRequest();
			else
			{
				fetchBook.BookName = rbbook.BookName;
				fetchBook.BookAuthor = rbbook.BookAuthor;
				fetchBook.Description = rbbook.Description;
				fetchBook.BookImageUrl = fetchBook.BookImageUrl;
				context.Rbbooks.Update(fetchBook);
				context.SaveChanges();
				return Ok();
			}
		}

		[HttpDelete]
		[Route("delete/{bookId}")]
		public ActionResult Delete(int bookId)
		{
			var data = context.Rbbooks.FirstOrDefault(p => p.BookId == bookId);
			if (data == null)
				return BadRequest();
			else
			{
				context.Rbbooks.Remove(data);
				context.SaveChanges();
				return Ok();
			}
		}


	}
}
