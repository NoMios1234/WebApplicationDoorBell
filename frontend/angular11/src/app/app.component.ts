import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular11';
}

/*
document.addEventListener('DOMContentLoaded', function (event) {
  //var baseHost = document.location.origin
  //var streamUrl = baseHost + ':81'
  var baseHost = "http://192.168.1.106"
  var streamUrl = "http://192.168.1.106:81"


  const hide = el => {
      el.classList.add('hidden')
  }
  const show = el => {
      el.classList.remove('hidden')
  }

  const disable = el => {
      el.classList.add('disabled')
      el.disabled = true
  }

  const enable = el => {
      el.classList.remove('disabled')
      el.disabled = false
  }

  const updateValue = (el, value, updateRemote) => {
      updateRemote = updateRemote == null ? true : updateRemote
      let initialValue
      if (el.type === 'checkbox') {
          initialValue = el.checked
          value = !!value
          el.checked = value
      } else {
          initialValue = el.value
          el.value = value
      }
  }

  function updateConfig(el) {
      let value
      switch (el.type) {
          case 'checkbox':
              value = el.checked ? 1 : 0
              break
          case 'range':
          case 'select-one':
              value = el.value
              break
          case 'button':
          case 'submit':
              value = '1'
              break
          default:
              return
      }

      const query = `${baseHost}/control?var=${el.id}&val=${value}`

      fetch(query)
          .then(response => {
              console.log(`request to ${query} finished, status: ${response.status}`)
          })
  }

  document
      .querySelectorAll('.close')
      .forEach(el => {
          el.onclick = () => {
              hide(el.parentNode)
          }
      })

  // read initial values
  fetch(`${baseHost}/status`)
      .then(function (response) {
          return response.json()
      })
      .then(function (state) {
          document
              .querySelectorAll('.default-action')
              .forEach(el => {
                  updateValue(el, state[el.id], false)
              })
      })

  const view = document.getElementById('stream')
  const viewContainer = document.getElementById('stream-container')
  const stillButton = document.getElementById('get-still')
  const streamButton = document.getElementById('toggle-stream')
  const closeButton = document.getElementById('close-stream')

  const stopStream = () => {
      window.stop();
      streamButton.innerHTML = 'Start Stream'
  }

  const startStream = () => {
      alert("start stream")
      view.src = `${streamUrl}/stream`
      show(viewContainer)
      streamButton.innerHTML = 'Stop Stream'
  }

  // Attach actions to buttons
  stillButton.onclick = () => {
      stopStream()
      view.src = `${baseHost}/capture?_cb=${Date.now()}`
      show(viewContainer)
  }

  closeButton.onclick = () => {
      stopStream()
      hide(viewContainer)
  }

  streamButton.onclick = () => {
      const streamEnabled = streamButton.innerHTML === 'Stop Stream'
      if (streamEnabled) {
          stopStream()
      } else {
          startStream()
      }
  }

  // Attach default on change action
  document
      .querySelectorAll('.default-action')
      .forEach(el => {
          el.onchange = () => updateConfig(el)
      })

  // Custom actions
})
*/