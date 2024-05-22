const outputElement = document.querySelector('.Output');
const sendButton = document.querySelector('.btn');
const promptInput = document.querySelector('#nome-box');
const messageContainer = document.querySelector('.meow')


sendButton.addEventListener('click', async () => {
    console.log('rawr')
    const response = await fetch('api/todo', {
        method: 'POST',
        headers: {
            'accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            'promp': `${promptInput.value}`
        })
    })

    if (response.ok){
        const data = await response.json();

       /*  outputElement.value = data.resposta */
       console.log(data.resposta)
       /* const pElement = document.createElement('p');
       pElement.className = 'message'
       pElement.textContent = `${data.resposta}` */
        outputElement.textContent = data.resposta
    }
    console.log(response)
})