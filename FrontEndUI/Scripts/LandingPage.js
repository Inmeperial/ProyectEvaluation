const URL = 'https://localhost:7055/api/NodeFiles';
const maxForTreeRecu = 300;

function addEventToElement(element) {
  element.addEventListener('click', function (e) {
    e.stopPropagation(); // needed to stop the propagation to others nodes.
    this.querySelector('.nested').classList.toggle('active');
    this.classList.toggle('caret-down');
  });
}

function recuMappingNodes(fatherNode, node, actualCount, maxCount) {
  if (actualCount >= maxCount) {
    return;
  }
  const liElement = document.createElement('li');
  fatherNode.appendChild(liElement);

  if (node.type === 'file') {
    liElement.innerText = node.name;
  } else {
    const spanElement = document.createElement('span');
    spanElement.innerText = node.name;
    liElement.appendChild(spanElement);
    spanElement.className = 'caret';
    const ulElement = document.createElement('ul');
    ulElement.className = 'nested';
    spanElement.appendChild(ulElement);
    addEventToElement(spanElement);

    for (let index = 0; index < node.files.length; index += 1) {
      recuMappingNodes(ulElement, node.files[index], actualCount + 1, maxCount);
    }
  }
}

// eslint-disable-next-line no-unused-vars
function GetNodes(indexVar) {
  fetch(URL)
    .then((response) => response.json())
    .then((data) => {
      const myUL = document.createElement('myUL');
      indexVar.after(myUL);
      for (let index = 0; index < data.length; index += 1) {
        recuMappingNodes(myUL, data[index], 0, maxForTreeRecu);
      }
    })
    .catch((error) => console.error('Unable to get items.', error));
}
