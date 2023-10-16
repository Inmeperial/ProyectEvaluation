const URL = 'https://localhost:7055/api/NodeFiles';

function displayItems(data) {
  console.error(data);
}

// eslint-disable-next-line no-unused-vars
function GetNodes() {
  fetch(URL)
    .then((response) => response.json())
    .then((data) => displayItems(data))
    .catch((error) => console.error('Unable to get items.', error));
}
