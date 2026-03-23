# ECommerce

This project is mainly starting out as an API that is meant to solidify my foundations in ASP.NET  
It might grow into something else, who knows :)  
Personally, I'm excited to find out.  

---

This is a general description of the project

## ECommerce API

This API connects to a Postgres Database that has three tables:  
- Products
- Sales
- Categories
  
1. Products and Sales have a many-to-many relationship, meaning products can have muliple sales, and sales can have multiple products.  
This is implemented by a join table.

2. All Products need to have a price. Multiple products can be sold at the same time.  

3. Apparently I need to provide a Postman Collection with all possible requests for the API. It's a json file that needs to be included in my PR(Although I've never done it even once).  

4. I've not been necessarily asked to create a UI to consume it, but maybe...  

5. The GetProducts and GetSales endpoints need to have pagination capabilities.  

6. Records can't be deleted, although I'll try and play around with soft deletes :)  

7. Prices CANNOT be updated!!! Why? Because I say so.  
