import React, { useState } from 'react'

export default function Bikes() {
    function getBikes() {
        const url = "https://localhost:7066/WeatherForecast"
        fetch(url, {
            method: 'GET'
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
                setBikes(usersFromServer)
            })
            .catch((error) => {
                console.log(error)
                alert(error);
            })
    }
    const [bikes,setBikes]= useState([]);
  return (
      <div className="table-responsive mt-5">
          <table className="table table-dark border-light">
              <thead>
                  <tr>
                      <th>Id</th>
                      <th>Tipo</th>
                      <th>Stato</th>
                      <th>Disponibilita</th>
                      <th>Operations</th>
                  </tr>
              </thead>
              <tbody>
                  {bikes.map((bike) => (
                      <tr key={bike.Id} >
                          <th scope="row">{bike.Id}</th>
                          <td>{bike.Type}</td>
                          <td>{bike.IsWorking}</td>
                          <td>{bike.LockOn}</td>
                          <td className="d-flex justify-space-between">
                              <button className="btn btn-primary ">Edit</button>
                              <button className="btn btn-danger">Delete</button>
                          </td>
                      </tr>
                  ))}
              </tbody>
          </table>
      </div>
  )
}
