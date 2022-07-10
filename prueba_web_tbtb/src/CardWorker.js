import React from 'react';

const CardWorker = (data) => {

    let users = data.data;
    
    return (
        <>
             <div className="container">
                <div className="album py-3">
                    <div className="container">
                        <div className="row row-cols-1 row-cols-sm-2 row-cols-md-2 row-cols-lg-3 g-3">
                            {users.map((item, index) => (
                                <>
                                    <div className="col">
                                        <div className="card border-info shadow-sm">
                                            <img src="#" className="card-img-top" alt="" />
                                            <div className="card-body" key={index}>
                                                <h5 className="card-title mb-4">{item.name}</h5>
                                                <p className="card-text text-start"><b>User:</b>{' '}{item.username}</p>
                                                <p className="card-text text-start"><b>Email:</b>{' '}{item.email}</p>
                                                <p className="card-text text-start"><b>Street:</b>{' '}{item.address.street}</p>
                                                <p className="card-text text-start"><b>Suite:</b>{' '}{item.address.suite}</p>
                                                <p className="card-text text-start"><b>City:</b>{' '}{item.address.city}</p>
                                                <p className="card-text text-start"><b>ZipCode:</b>{' '}{item.address.zipcode}</p>
                                                <p className="card-text text-start"><b>Ubication:</b>{' '}{item.address.geo.lat},{item.address.geo.lng}</p>
                                                <p className="card-text text-start"><b>Phone:</b>{' '}{item.phone}</p>
                                                <p className="card-text text-start"><b>Website:</b>{' '}{item.website}</p>
                                                <p className="card-text text-start"><b>Company:</b>{' '}{item.company.name}</p>
                                                <p className="card-text text-start"><b>Phrase:</b>{' '}{item.company.catchPhrase}</p>
                                                <p className="card-text text-start"><b>BS:</b>{' '}{item.company.bs}</p>
                                            </div>
                                        </div>
                                    </div>
                                </>
                            ))}
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}

export default CardWorker;