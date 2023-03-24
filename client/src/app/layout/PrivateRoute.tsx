import { ComponentType } from "react";

import { Navigate, useNavigate, useLocation } from "react-router";
import { useAppSelector } from "../store/configureStore";
import { toast } from "react-toastify";

interface Props {
  children: JSX.Element;
  roles?: string[];
}

export default function PrivateRoute({ children, roles }: Props) {
  const { user } = useAppSelector((state) => state.account);
  const location = useLocation();
  console.log(user);
  if (!user) {
    return <Navigate to="/login" state={{ from: location.pathname }} />;
  }
  if (roles && !roles?.some((r) => user.roles?.includes(r))) {
    toast.error("Not authorised to access this area");
    return <Navigate to={{ pathname: "/catalog" }} />;
  }
  return children;
}
