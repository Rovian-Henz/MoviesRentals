# MovieRental Exercise

This is a dummy representation of a movie rental system.
Can you help us fix some issues and implement missing features?

 * The app is throwing an error when we start, please help us. Also, tell us what caused the issue.
    -  It was using singleton instead of scoped in the error itself it says that cannot initialize it as singleton because MovieRentalDbContext is scoped. So I just changed it to scoped. It cant be singleton because of lifetime, it is created only once in singleton but i need it to be created for every request, so scoped is the way.
 * The rental class has a method to save, but it is not async, can you make it async and explain to us what is the difference?
    - Added ct to be able to cancel in case it starts to take to long. It is best to use async because it does not hold the software until we get the response, also helps getting more simultaneous requests
 * Please finish the method to filter rentals by customer name, and add the new endpoint.
    - done
 * We noticed we do not have a table for customers, it is not good to have just the customer name in the rental.
   Can you help us add a new entity for this? Don't forget to change the customer name field to a foreign key, and fix your previous method!
    - OK
 * In the MovieFeatures class, there is a method to list all movies, tell us your opinion about it.
    - it does what is necessary, it could be improved like using pagination in case it has lots of data, or even return a read only list, we could also order it.
 * No exceptions are being caught in this api, how would you deal with these exceptions?
    - we could deal with them using a middleware to get all types of exceptions, we could add the specific/meaningful exceptions within the methods (see GetRentalsByCustomerName) and also model validations in the apis
