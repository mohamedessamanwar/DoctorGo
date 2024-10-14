document.getElementById('submit').addEventListener('click', async () => {  // Mark the function as async
    var comment = document.getElementById('commentText').value;
    var id = document.getElementById('id').value;

    let obj = {
        Comment: comment,
        DocId: id
    };
    console.log(obj)

    try {
        let result = await fetch('https://localhost:44326/Comment/AddComment', {
            method: 'POST',                    // Set HTTP method to POST
            headers: {
                'Content-Type': 'application/json',  // Specify content type as JSON
            },
            body: JSON.stringify(obj),  // Convert JavaScript object to JSON string
            credentials: 'include'       // Include cookies in the request
        });

        if (result.ok) {
            let responseData = await result.json();
            console.log(responseData);

            // Create a new list item (li) element
            let newComment = document.createElement('li');
            newComment.className = 'media mb-3'; // Set the class for styling

            // Set the inner HTML of the new comment
            newComment.innerHTML = `
        <div class="media-body">
            <h5 class="mt-0 mb-1">${responseData.data.userName}</h5>
            <small class="text-muted">${responseData.data.commentAt}</small>
            <p class="mt-2">${responseData.data.comment}</p>
        </div>
    `;

            // Append the newly created comment to the ul element
            document.getElementById('ul').appendChild(newComment);
        }
 else {
            let responseData = await result.json();
            document.getElementById('span').innerText = responseData.message;
        }
    } catch (error) {
        console.error("Error during fetch:", error);
        document.getElementById('span').innerText = "LogIN First";
    }
});

var connection = new signalR.HubConnectionBuilder().withUrl("/commentHub").build();

connection.start().then(function () {
    console.log("SignalR connection established.");
}).catch(function (err) {
    console.error(err.toString());
});

// Listen for the "ReceiveComment" event from the server
connection.on("ReceiveComment", function (responseData) {
    // Create a new list item (li) element
    let newComment = document.createElement('li');
    newComment.className = 'media mb-3'; // Set the class for styling

    // Set the inner HTML of the new comment
    newComment.innerHTML = `
        <div class="media-body">
            <h5 class="mt-0 mb-1">${responseData.userName}</h5>
            <small class="text-muted">${responseData.commentAt}</small>
            <p class="mt-2">${responseData.comment}</p>
        </div>
    `;

    // Append the newly created comment to the ul element
    document.getElementById('ul').appendChild(newComment);
});



