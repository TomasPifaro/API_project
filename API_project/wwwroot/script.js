function postData(data){
    fetch('/api/TodoItems', {
        method: 'POST',
        body: JSON.stringify(data),
        headers:{
            'Content-Type': 'appplication/json'
        }
    })
    .then(Response => Response.json())
    .then(data => console.log(data));
}

const data = {promp: 'example'};
postData(data);