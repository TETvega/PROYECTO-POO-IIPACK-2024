import { CatalagoProductsList } from "../components/catalago"


export const CatalagoProducts = () => {
  return (
    <div className="w-full mt-4 p-6">
        <div className=" justify-center items-center font-bold ">
            <h1 className=" text-6xl text-center">Mobiliario en Alquiler</h1>
        </div>
        <div className=" justify-between items-center ">
            <CatalagoProductsList/>
        </div>
    </div>
  )
}
