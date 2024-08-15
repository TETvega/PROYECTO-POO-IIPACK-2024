export const HeroSection = () => {
  return (
    <div className="mt-6 flex items-center justify-center h-[89vh] bg-red-600 w-full">
    <div className="text-center">
      <h1 className="text-4xl font-bold mb-6">¡Bienvenido a Nuestro Sitio!</h1>
      <div>
        <button className="bg-blue-500 text-white py-2 px-4 rounded mr-4 hover:bg-blue-600">
          Reserva ahora
        </button>
        <button className="bg-green-500 text-white py-2 px-4 rounded hover:bg-green-600">
          Login
        </button>
      </div>
    </div>
  </div>
  )
}
